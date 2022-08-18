using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    public int duration; //milliseconds value of how long the powerup should last

    
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(powerupEffect.timedPowerUp)
            {
                Destroy(gameObject);
                powerupEffect.Apply(collision.gameObject);
                await Task.Delay(duration);
                powerupEffect.Remove(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
                powerupEffect.Apply(collision.gameObject);
            }
            
        }

        

    }
    
}
