using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ShootingBuff")]
public class ShootingBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {   
        if(target.GetComponent<PlayerController>().shootingSpeed - amount >= 1)
        {
            target.GetComponent<PlayerController>().shootingSpeed = target.GetComponent<PlayerController>().shootingSpeed - amount;
        }
        else
        {
            target.GetComponent<PlayerController>().shootingSpeed = 1;
        }
        

    }

    public override void Remove(GameObject target)
    {
        target.GetComponent<PlayerController>().shootingSpeed = target.GetComponent<PlayerController>().shootingSpeed + amount;
    }
        
}