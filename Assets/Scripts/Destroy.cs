using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject boostPlatformPrefab;
    public GameObject carrot;

    private GameObject myPlatform;

    public float levelWidth = 30f;
    public float minY = 10f;
    public float maxY = 25f;
    public float boostChance = 0.05f;
    private float randomX, randomY;

    private void Update()
    {

        if (player.transform.position.y > transform.position.y + 10)
        {
            transform.position = new Vector2(0f, player.transform.position.y + 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            Destroy(collision.gameObject);

            randomX = Random.Range(-levelWidth * 2f, levelWidth * 2f);
            randomY = Random.Range(minY, maxY);

            Vector2 spawnPosition = new Vector2(player.transform.position.x + randomX, player.transform.position.y + randomY);


            if (randomY < (maxY - minY) * boostChance + minY)
            {
                Instantiate(boostPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }

        if (collision.gameObject.tag == "carrot")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
