using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public PlayerData playerData;  //playerData.jumpforce   playerData.groundDistance  playerData.jumpTime
    [SerializeField] private LayerMask groundedLayer;
    [SerializeField] Transform feetPos;
    



    private void Update()
    {
        playerData.isGrounded = Physics2D.OverlapCircle(feetPos.position,playerData.groundDistance,groundedLayer);  // True or false dependiendo si el OVERLAPCIRCLEcirculo toca el piso
        
        if (playerData.isGrounded && Input.GetButtonDown("Jump"))
        {
            playerData.isJumping = true;
            rb.velocity = Vector2.up * playerData.jumpForce;
        }
        if (playerData.isJumping && Input.GetButton("Jump"))
        {
            playerData.isJumping = true;
            if (playerData.jumpTimer < playerData.jumpTime) 
            {
                rb.velocity = Vector2.up * playerData.jumpForce;

                playerData.jumpTimer += Time.deltaTime;
            }
            else
            {
                playerData.isJumping = false; 
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            playerData.isJumping = false;
            
            playerData.jumpTimer = 0 ;
        }

    }
}
