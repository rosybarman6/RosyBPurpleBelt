﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    public GameObject splash;
    public GameObject gameOverText;
    public GameObject scoreSystem;
    public Text scoreText;
    public int pointsWorth = 1;
    private bool smokeCleared = true;
    private int bestScore = 0;
    public Text bestScoreText;
    private bool beatBestScore;

    private int score;
    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = playerPrefab;
        scoreText.enabled = false;
        bestScoreText.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(this.gameObject);
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(true);
        gameOverText.SetActive(false);
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("smoke " + smokeCleared);

        if (!gameStarted)
        {
            if (Input.anyKeyDown && smokeCleared)
            {
                smokeCleared = false;
                ResetGame();
            }
        }
        else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject bombObject in nextBomb)
        {
            if (!gameStarted)
            {
                Destroy(bombObject);
            } else if (bombObject.transform.position.y < (-screenBounds.y) && gameStarted)
            {
                scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
            }
        } 

        if (!gameStarted)
        {
            var textColor = "#323232";

            if (beatBestScore)
            {
                textColor = "#F00";
            }

            bestScoreText.text = "<color=" + textColor + ">Best Score: " + bestScore.ToString() + "</color>";
        }
        else
        {
            bestScoreText.text = "";
        }
    }

    void ResetGame()
    {
        Debug.Log("reset game");
        spawner.active = true;
        title.SetActive(false);
        splash.SetActive(false);
        gameOverText.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
        scoreText.enabled = true;
        scoreSystem.GetComponent<Score>().score = 0;
        scoreSystem.GetComponent<Score>().Start();
        beatBestScore = false;
        bestScoreText.enabled = true;
    }


    void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;
        
       
        Invoke("SplashScreen", 2f);

        score = scoreSystem.GetComponent<Score>().score;

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            beatBestScore = true;
            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }
    }

    void SplashScreen()
    {
        Debug.Log("2 secod timer");
        smokeCleared = true;
        splash.SetActive(true);
    }
}


