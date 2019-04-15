using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float startSpawnInterval;
    public float minSpawnInterval;
    public float spawnIntervalDecrease;
    private float spawnInterval;

    public Obstacle[] obstacles;

    public Transform spawnPoint;
    public Transform destroyPoint;

    private float cooldown = 0f;

    void Start()
    {
        spawnInterval = startSpawnInterval;  
    }

    void Update()
    {
        if(cooldown <= 0f)
        {
            SpawnObstacle();
            cooldown = spawnInterval;

            DecreaseSpawnInterval();
        }
        cooldown -= Time.deltaTime;
    }

    void SpawnObstacle()
    {
        int rand = Random.Range(0, obstacles.Length);
        Obstacle obstacle = Instantiate(obstacles[rand], spawnPoint.position, Quaternion.identity);
        obstacle.destroyPoint = destroyPoint;
    }

    void DecreaseSpawnInterval()
    {
        if (spawnInterval - spawnIntervalDecrease < minSpawnInterval)
            spawnInterval = minSpawnInterval;
        else
            spawnInterval -= spawnIntervalDecrease;
    }
}
