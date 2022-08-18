using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupEffect : ScriptableObject
{   
    public bool timedPowerUp;
    public virtual void Apply(GameObject target) {}
    public virtual void Remove(GameObject target) {}


}