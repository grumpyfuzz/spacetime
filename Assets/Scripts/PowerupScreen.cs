using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScreen : MonoBehaviour
{

    public GameObject powerUpMenu;
    public GameObject player;

    public bool firstPowerUp = false;
    
    // Update is called once per frame
    void Update()
    {
        /*if(Game.GetScore() == 100 && !firstPowerUp)
        {
            powerUpMenu.SetActive(true);
            Time.timeScale = 0f;
            firstPowerUp = true;
        }*/
    }

    public void ShootingBuff()
    {
        player.GetComponent<PlayerController>().shootingSpeed -= 2;
        firstPowerUp = true;
        Close();
    }

    public void HealthBuff()
    {
        player.GetComponent<PlayerController>().maxHealth = 150;
        player.GetComponent<PlayerController>().health = 150;
        player.GetComponent<PlayerController>().healthBar.SetMaxHealth(player.GetComponent<PlayerController>().health);
        player.GetComponent<PlayerController>().healthBar.SetHealth(player.GetComponent<PlayerController>().health);
        firstPowerUp = true;
        Close();
    }

    public void Close()
    {
        powerUpMenu.SetActive(false);
    }

    public void Load()
    {
        powerUpMenu.SetActive(true);
    }


}
