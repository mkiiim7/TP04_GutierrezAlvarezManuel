using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] public AudioSource audioSourcePlay;
    [SerializeField] public AudioSource audioSourceSlow;

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Pico")
        {
            Destroy(gameObject);
            gameManager.GameOver();
            audioSourcePlay.mute = true;
            
        }


        if (other.transform.tag == "Sol")
        {
           

            Destroy(other.gameObject);
            audioSourcePlay.mute= true;
            audioSourceSlow.mute = false;
            gameManager.score += 2;
            Time.timeScale = 0.4f;
            Invoke("DelayTiempo",2);
            
          
            



        }
    }
    private void DelayTiempo()
     {

        Time.timeScale = 1f;
        audioSourcePlay.mute = false;
        audioSourceSlow.mute = true;
    }
}
