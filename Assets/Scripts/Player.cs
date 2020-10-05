using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instance;
    public float moveSpeed = 10f;

    float movement;

    Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Text scoreText;

    public float currScore = 0.0f;
    private float highScore;

    private float scoreMultiplier = 1f;

    private bool spawnEnemies = false;

    public bool StartSpawning { get { return spawnEnemies; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;


        highScore = PlayerPrefs.GetFloat("highScore");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (movement < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        } else if (movement > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (rb.velocity.y > 0 && transform.position.y > currScore)
        {
            currScore = transform.position.y * scoreMultiplier;
        }

        if (currScore > 100)
        {
            spawnEnemies = true;
        }

        scoreText.text = "Score: " + Mathf.Round(currScore).ToString();
    }

    void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    public void startColorChange()
    {
        StartCoroutine(colorChange());
    }

    IEnumerator colorChange()
    {
        int counter = 0;
        while (counter < 18)
        {

            if (sprite != null)
            {
                Color rainbow = new Color(Random.value, Random.value, Random.value);

                sprite.color = rainbow;
            }
            yield return new WaitForSeconds(0.1f);
            counter += 1;
        }

        sprite.color = new Color(255, 255, 255);
    }

    private void OnDisable()
    {
        if (currScore > highScore)
        {
            PlayerPrefs.SetFloat("highScore", Mathf.Round(currScore));
            PlayerPrefs.Save();
        }
    }
}