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
    public CameraShake cameraShake;

    public int playerHealth = 3;
    public bool isGameOver = false;

    public static int points = 0;

    private void Awake()
    {
        points = 0;
        if (Instance == null)
        {
            Instance = this;
           
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(this.gameObject);

        }
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetGame();
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
        StartCoroutine(cameraShake.Shake(.15f, .1f));

        playerHealth--;
        healthText.text = "Health: " + playerHealth;
        if (playerHealth == 0)
        {

            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            GameManager.Instance.GameOver();
            player.LockMovement();
          

        }
    }

    public void ResetGame()
    {
        isGameOver = false;
        
        
            
        playerHealth = 3;
        
       
    }
    public void GameOver()
    {
        isGameOver = true;
    
    }

}
