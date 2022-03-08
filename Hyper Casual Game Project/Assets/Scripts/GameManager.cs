using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gamePlayUI;
    public GameObject spawner;



    public static GameManager instance;
    public bool gameStarted =false;

    public GameObject player;

    int lives = 2;
    int score = 0;

    public Text scoreText;
    public Text livesText;

    private void Awake()
    {
        instance = this;
       
    }


    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        spawner.SetActive(true);



    }
    public void GameOver()
    {
        player.SetActive(false);
        Invoke("ReloadLevel",1.5f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");

    }

    public void UpdateLives()
    {
        if (lives <=0)
        {
            GameOver();
        }
        else
        {
            lives--;
            livesText.text = "Lives :" + lives;
            print("lives : "+lives);
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score : " + score;
        print("Score : " +score);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
