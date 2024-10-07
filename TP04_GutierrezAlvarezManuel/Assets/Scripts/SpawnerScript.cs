using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float obstacleSpwanTime = 2f;
    [SerializeField] private float timeUntilObstacleSpawn;
    [SerializeField] private float obstacleSpeed = 1f;
    [SerializeField] float minTrasx= 20;
    [SerializeField] float maxTrasx = 25;

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

        var wantedx = Random.Range(minTrasx, maxTrasx);
        var position = new Vector3(wantedx +12 , transform.position.y);
        GameObject spawnedObstacle = Instantiate(obastacleToSpawn, position , Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed * playerData.velocityx * Time.deltaTime ;


    }
}
