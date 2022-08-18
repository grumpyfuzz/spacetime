using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    int score;
    public static Game Instance;

    public PauseMenu pauseMenu;
    public PowerupScreen powerupScreen;
    private bool isFrozen = false; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseMenu.pauseMenuUI.activeSelf && !powerupScreen.powerUpMenu.activeSelf) // when in base game
            {
                pauseMenu.Load();
                Freeze();
            }
            else if(pauseMenu.pauseMenuUI.activeSelf && !powerupScreen.powerUpMenu.activeSelf)
            {  
                pauseMenu.Close(); // can make this an unpause
                Unfreeze();
            }
            else if(!pauseMenu.pauseMenuUI.activeSelf && powerupScreen.powerUpMenu.activeSelf)
            {
                pauseMenu.Load(); // can make this a pause
                Freeze();
            }
            else // in both screens
            {
                pauseMenu.Close();
            }


        }

        if(GetScore() == 10 && !powerupScreen.firstPowerUp)
        {
            Freeze();
            powerupScreen.Load();
        }

    }

    void Awake()
    {
        if (Instance == null) Instance = this;  
        else Destroy(this.gameObject);
    }

    public static void AddToScore(int points)
    {
        Instance.score += points;
    }
    public static int GetScore()
    {
        return Instance.score;
    }

    public static bool GetIsPaused()
    {
        return Instance.isFrozen; 
    }

    public void Unfreeze()
    {
        Time.timeScale = 1f;
        isFrozen = false;
    }

    public void Freeze()
    {
        Time.timeScale = 0f;
        isFrozen = true;
    }
}