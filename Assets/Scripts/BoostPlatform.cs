using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : MonoBehaviour
{

    public float jumpForce = 60f;
    public GameObject carrot;

    private void Start()
    {
        Vector2 spawnPosition = transform.position;
        spawnPosition.y += 0.8f;
        Instantiate(carrot, spawnPosition, Quaternion.identity);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y <= 0f)
        {
            collision.gameObject.GetComponent<Player>().startColorChange();

            LifeControlScript.health += 1;

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
