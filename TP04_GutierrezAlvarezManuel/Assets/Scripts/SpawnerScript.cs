using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float obstacleSpwanTime = 2f;
    [SerializeField] private float timeUntilObstacleSpawn;
    [SerializeField] private float obstacleSpeed = 1f;

    [SerializeField] public PlayerData playerData;


    private void Update()
    {
        SpawnLoop();
        
    }

  
    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime*0.1f;

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
        obstacleRB.velocity = Vector2.left * obstacleSpeed * playerData.velocityx * Time.deltaTime ;


    }
}
