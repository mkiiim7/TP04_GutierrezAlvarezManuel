using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    
    [SerializeField] public UIMainMENU uiMainMenu;


    private void Update()
    {
        if (uiMainMenu.pausa == false)
        {
            score += Time.deltaTime;
        }
    }


    public void GameOver()
    {
        score = 0;
        uiMainMenu.pausa = true;
        Time.timeScale = 0;


    }

    public string PrettyScore()
    {

        return Mathf.RoundToInt(score).ToString();
    }


}
