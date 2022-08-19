using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timer = 0.0f;
    bool isClone = false;
    float randtime;
    public float health;
    public float maxHealth;
    public GameObject spawnPoint;
    public GameObject enemy;
    public GameObject increasedShootingSpeed;
    public GameObject healthIncrease;
    public GameObject moreSpawners;

    public EnemyHealthBar enemyHealthBar;
 
    // Start is called before the first frame update
    void Start()
    {
        randtime = Random.Range(0.5f, 2f);
        if(isClone)
        {
            Destroy(this.gameObject, 6f);
            enemyHealthBar.gameObject.SetActive(false);
        }
        else{
            enemyHealthBar.UpdateHealthBar(maxHealth, health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > randtime)
        {
            GameObject ship = Spawn();
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.right);
            ship.GetComponent<Rigidbody2D>().velocity = dir * Random.Range(175f, 350f) * Time.deltaTime;
            randtime = Random.Range(0.1f, 0.2f);
            timer = 0.0f;
        }
        timer += Time.deltaTime;

        if (health <= 0) {
            Destroy(this.gameObject, 0.5f);
        }

     
    }

    GameObject Spawn()
    {
        
        float randNum = Random.Range(0.0f, 1.0f);

        if (randNum >= 0.97f)
        {   
            GameObject tempSpawner = Instantiate(moreSpawners, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f));
            tempSpawner.gameObject.GetComponent<EnemySpawner>().isClone = true;
            return tempSpawner;
        }

        if (randNum >= 0.94f)
        {
            return Instantiate(increasedShootingSpeed, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f));
        }

        if (randNum >= 0.92f)
        {
            return Instantiate(healthIncrease, spawnPoint.transform.position, Quaternion.Euler(0f, 0f, 0f));
        }

        

        return Instantiate(enemy, spawnPoint.transform.position, Quaternion.Euler(0f, 0f,0f));
       
    }
}