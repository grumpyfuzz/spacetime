using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeirdEnemyController : MonoBehaviour
{
    public float bounds;
    

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > bounds || this.transform.position.x < -bounds || this.transform.position.y > bounds || this.transform.position.x < -bounds)
        {
            
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Game.AddToScore(1);
            Destroy(gameObject);
        }
    }
   
}