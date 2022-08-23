using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;

    float timer = 0.0f;
    
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = (transform.up).normalized * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 4.0f)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Powerup")
        {
            GameObject explode = Instantiate(explosion.gameObject, transform.position, transform.rotation);

            //explode.Play();
            Destroy(explode, explosion.main.duration);

            Destroy(gameObject);
            //check if clone to do damage possibly, original enemey spawner infinite health?
        }

        if (collision.tag == "EnemySpawner")
        {
            collision.gameObject.GetComponent<EnemySpawner>().health -= 2f;
            collision.gameObject.GetComponent<EnemySpawner>().enemyHealthBar.UpdateHealthBar(collision.gameObject.GetComponent<EnemySpawner>().maxHealth, collision.gameObject.GetComponent<EnemySpawner>().health);
        }



    }
}
