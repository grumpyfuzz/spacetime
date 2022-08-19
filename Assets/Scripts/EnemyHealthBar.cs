using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
    public Image HealthBarSprite;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        HealthBarSprite.fillAmount = currentHealth / maxHealth;
    }
}
