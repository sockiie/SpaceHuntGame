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
    public GameObject explosionEffect;
    public GameObject playerShield;

    public int playerHealth = 3;
    public bool isGameOver = false;
    public bool PowerUpp = false;

    public static int points = 0;

    private void Awake()

    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
        isGameOver = false;
>>>>>>> 3ca8a104ffa634691386fbe288a57442b0922bed
        gameoverText.SetActive(false);
=======
>>>>>>> parent of 0c3683f (Merge branch 'main' of https://github.com/sockiie/SpaceHuntGame into main)
=======
>>>>>>> parent of 0c3683f (Merge branch 'main' of https://github.com/sockiie/SpaceHuntGame into main)
        playerShield.SetActive(false);
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
        Explode();
        //StartCoroutine(cameraShake.Shake(.15f, .4f));
        if (PowerUpp == true)
        {

            FindObjectOfType<AudioManager>().Play("CrashKometSchild");

            PowerUpp = false;
            playerShield.SetActive(false);

        }
        else
        playerHealth--;
        healthText.text = "Health: " + playerHealth;
        if (playerHealth == 0)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            gameoverText.SetActive(true);
<<<<<<< HEAD

=======
            isGameOver = true;
=======
=======
>>>>>>> parent of 0c3683f (Merge branch 'main' of https://github.com/sockiie/SpaceHuntGame into main)

>>>>>>> parent of 0c3683f (Merge branch 'main' of https://github.com/sockiie/SpaceHuntGame into main)
>>>>>>> 3ca8a104ffa634691386fbe288a57442b0922bed
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

    public void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("Boom");
    }

    public void PowerUp(Collider player)
    {

        PowerUpp = true;
        playerShield.SetActive(true);
    Debug.Log("POOOWEER");
    }



}
