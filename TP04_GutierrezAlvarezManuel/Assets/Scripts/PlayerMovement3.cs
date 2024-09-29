using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public PlayerData playerData;  //playerData.jumpforce   playerData.groundDistance 
    [SerializeField] private LayerMask groundedLayer;
    [SerializeField] Transform feetPos;
    [SerializeField] private Transform GFX;
    [SerializeField] private KeyCode keyUp = KeyCode.UpArrow;
    [SerializeField] private KeyCode keyDown = KeyCode.DownArrow;

    [SerializeField] private float jumpTime = 0.5f;
    [SerializeField] private float crouchHeight = 0.2f;



    private void Update()
    {
        playerData.isGrounded = Physics2D.OverlapCircle(feetPos.position, playerData.groundDistance, groundedLayer);  // True or false dependiendo si el OVERLAPCIRCLE circulo toca el piso
        

        if (playerData.isGrounded && Input.GetKeyDown(keyUp))
        {
            playerData.isJumping = true;
            rb.velocity = Vector2.up * playerData.jumpForce;
        }
        if (playerData.isJumping && Input.GetKey(keyUp))
        {
            playerData.isJumping = true;
            if (playerData.jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * playerData.jumpForce;

                playerData.jumpTimer += Time.deltaTime;
            }
            else
            {
                 playerData.isJumping = false;
            }
        }
        if (Input.GetKeyUp(keyUp))
        {
            playerData.isJumping = false;

            playerData.jumpTimer = 0;
        }


        if(playerData.isGrounded && Input.GetKey(keyDown))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
            
            if (playerData.isJumping)
            {
                GFX.localScale = new Vector3(GFX.localScale.x, 0.3f, GFX.localScale.z);
            }
        }
        if (playerData.isGrounded && Input.GetKeyUp(keyDown))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 0.3f, GFX.localScale.z);
        }
    }
}
