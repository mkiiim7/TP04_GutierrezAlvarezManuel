using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="PlayerData", menuName = "Player/Data", order = 1)]

public class PlayerData : ScriptableObject 
{
    [Header("Movement/Jump")] 
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;
    public float groundDistance = 0.3f;
    public float jumpTimer;

    public bool isGrounded = false;
    public bool isJumping = false;

    public float velocityx = 1f;
    public float velocityy = 1f;
    
   
}
