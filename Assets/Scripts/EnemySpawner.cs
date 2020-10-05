using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private float xLimit = 0;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private GameObject[] enemy;
    [SerializeField]
    private Wave[] wave;

    private float currentTime;

    List<float> remainingPositions = new List<float>();

    private int waveId;
    float xPos = 0f;
    int rand;

    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
    }

    void Update()
    {
        if (Player.instance.StartSpawning == true)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SelectWave();
            }
        }
    }

    void SpawnEnemy(float xPost)
    {
        int r = Random.Range(0, 1);
        GameObject enemyObj = Instantiate(enemy[r], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }

    void SelectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);

        waveId = Random.Range(0, wave.Length);

        currentTime = wave[waveId].delayTime;

        if (wave[waveId].spawnAmount == 1)
        {
            xPos = Random.Range(-xLimit, xLimit);
        }
        else if (wave[waveId].spawnAmount > 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = player.transform.position.x + remainingPositions[rand];

            remainingPositions.RemoveAt(rand);
        }

        for (int i=0; i<wave[waveId].spawnAmount; i++)
        {
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = player.transform.position.x + remainingPositions[rand];

            remainingPositions.RemoveAt(rand);
        }
    }
}

[System.Serializable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
}