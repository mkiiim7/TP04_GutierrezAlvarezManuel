using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpwanTime = 2f;
    private float timeUntilObstacleSpawn;
    [SerializeField] public PlayerData playerData;


    private void Update()
    {
        SpawnLoop();
        
    }

  
    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpwanTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0;
        }
    }
    private void Spawn()
    {
        GameObject obastacleToSpawn = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obastacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * playerData.velocityx * Time.deltaTime;


    }
}
