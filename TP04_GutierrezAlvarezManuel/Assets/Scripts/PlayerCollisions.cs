using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] public GameManager gameManager; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Pico")
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
        if (other.transform.tag == "Sol")
        {
            Destroy(other.gameObject);
            gameManager.score += 2;
            Time.timeScale = 0.4f;
            Invoke("DelayTiempo",2);



        }
    }
    private void DelayTiempo()
     {

        Time.timeScale = 1f;

    }
}
