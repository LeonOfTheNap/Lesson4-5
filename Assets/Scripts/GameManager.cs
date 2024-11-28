using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    
    public float worldScrollingSpeed = 0.2f;
    public float score;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void FixedUpdate()
    {
        score += worldScrollingSpeed;
        UpdateScoreOnScreen();
    }

    void UpdateScoreOnScreen()
    {
        scoreText.text = score.ToString("0");
    }
}
