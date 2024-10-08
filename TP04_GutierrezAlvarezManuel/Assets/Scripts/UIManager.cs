using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] public GameManager gameManager;

    private void OnGUI()
    {
        scoreUI.text = gameManager.PrettyScore();
    }
}
