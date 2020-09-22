using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBrickNumber()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            GameOver();
        }
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //check for 0 lives (trigger game end)
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }


    public void UpdateScore(int changeInScore)
    {
        score += changeInScore;

        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene("level1");
    }

}
