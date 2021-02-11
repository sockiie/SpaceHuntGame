using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public Text healthText;
    public Text pointsText;
    public PlayerMovement player;

    public int playerHealth = 3;
    public bool isGameOver = false;

    public int points = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            Instance = new GameManager();
        }
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetGame();
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }

    }

        internal void CoinPickUp()
    {
        points++;
        pointsText.text = "Points: " + points;
    }

    public void PlayerHit()
    {
        playerHealth--;
        healthText.text = "Health: " + playerHealth;
        if (playerHealth == 0)
        {
            GameManager.Instance.GameOver();
            player.LockMovement();
          

        }
    }

    public void ResetGame()
    {
        isGameOver = false;
        
        
            points = 0;
        playerHealth = 3;
        
       
    }
    public void GameOver()
    {
        isGameOver = true;
    
    }

}
