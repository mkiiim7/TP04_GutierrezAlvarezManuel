using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] public PlayerData playerData;  //playerData.jumpforce   playerData.groundDistance  playerData.jumpTime
    [SerializeField] private LayerMask groundedLayer;
    [SerializeField] Transform feetPos;
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;
    public float groundDistance = 0.3f;
    public float jumpTimer;

    public bool isGrounded = false;
    public bool isJumping = false;




    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundedLayer);  // True or false dependiendo si el OVERLAPCIRCLEcirculo toca el piso

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (isJumping && Input.GetButton("Jump"))
        {
            isJumping = true;
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;

            jumpTimer = 0;
        }

    }
}
