using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FallThreshold : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Player)
        {
            if (Player.transform.position.y > transform.position.y + 70)
            {
                transform.position = new Vector2(0f, Player.transform.position.y - 70);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Defeat");
        }
    }
}
