using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    
    public float worldScrollingSpeed = 0.2f;
    public float score;

    public bool inGame; //provjera jesmo li pokrenuli igru
    public GameObject resetButton; //referenca na Reset Button
    
    // Start is called before the first frame update
    void Start()
    {
            instance = this;

            InitializeGame();
    }

    void InitializeGame()
    {
        inGame = true;
    }
    
    void FixedUpdate()
    {
        if (!GameManager.instance.inGame) return;
        
        score += worldScrollingSpeed;
        UpdateScoreOnScreen();
    }

    void UpdateScoreOnScreen()
    {
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {   
        inGame = false; //trenutno ne igramo igru
        resetButton.SetActive(true); //pokaži Reset Button
    }

    public void RestartGame()
    {
        //ponovo učitaj scenu s indexom 0
        SceneManager.LoadScene(0);
    }
}
