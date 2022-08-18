using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {   
        if(target.GetComponent<PlayerController>().health != target.GetComponent<PlayerController>().maxHealth)
        {
            target.GetComponent<PlayerController>().health = target.GetComponent<PlayerController>().health + amount;
            target.GetComponent<PlayerController>().healthBar.SetHealth(target.GetComponent<PlayerController>().health);
        }
    }

}
