using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{

    [SerializeField] PlayerData playerData;
    [SerializeField] float realVelocity = 1;

    [SerializeField] float depht = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        realVelocity = playerData.velocityx * 2 /depht;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.deltaTime;

        if (pos.x <= -16)
        {
            pos.x = 16;
        }
        transform.position = pos;
    }
}
