using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{

    [SerializeField] protected float movementSpeed;

    [SerializeField] public float shootingSpeed;
    [SerializeField] public int health;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject muzzle;

    private Rigidbody2D rigidBody;

    public int maxHealth;
    private float xInput;
    private float yInput;
    private float frameCounter;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        rigidBody = GetComponent<Rigidbody2D>();
        frameCounter = 0;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {   
        // follow mouse, can be good for a cursor
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //transform.position = mousePosition;
        
        //point player towards cursor
        if(!Game.GetIsPaused())
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 90f);
        }
    }

    void FixedUpdate()
    {
        movePlayer();
        if(frameCounter % shootingSpeed == 0){
            shoot();
            frameCounter = 0;
        }
        frameCounter++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            health -= 50;
            healthBar.SetHealth(health);
            Destroy(collision.gameObject);
        }
        if(health <= 0)
        {
            onDeath();
        }
    }

    void movePlayer()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        rigidBody.velocity = (new Vector2(xInput, yInput)).normalized * movementSpeed;
        
    }

    void shoot(){

        GameObject e = Instantiate(bullet) as GameObject;
        e.transform.position = muzzle.transform.position;
        e.transform.rotation = transform.rotation;

    }

    private async void onDeath()
    {
            Destroy(gameObject);
            // currently loads start menu but will want an alternative screen, add a delay too
            await Task.Delay(3000);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
