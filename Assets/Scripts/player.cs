using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class player : MonoBehaviour
{


    private Rigidbody2D rb;
    public Transform gun;
    public GameObject bullet;
    private float bulletTime;


    public float movementSpeed = 5f;
    public float MaxTilt = 2f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     

        if (transform.position.x <= -4.2f)
        {
            transform.position = new Vector3(4.1f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 4.1f)
        {
            transform.position = new Vector3(-4.2f, transform.position.y, transform.position.z);
        }

        bulletTime += Time.deltaTime;


        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Instantiate(bullet, gun.position, gun.rotation);
                bulletTime = 0f;
            }
        }

       
        float Tilt = Input.acceleration.x;
        Tilt = Mathf.Clamp(Tilt, -MaxTilt, MaxTilt);
        Vector3 moveDirection = new Vector3(Tilt, 0f, 0f);
        Vector3 playerVelocity = moveDirection * movementSpeed;

        playerVelocity.y = rb.velocity.y;

        rb.velocity = playerVelocity;
    }

    private void FixedUpdate()
    {
        /*Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;*/

        

        /*if(Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }*/

        if(Input.acceleration.x > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        if(Input .acceleration.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        rb.velocity = new Vector2(Input.acceleration.x * movementSpeed, rb.velocity.y);
        
    }
    
    public void restart()
    {
        Invoke("destroy", 1f);
    }
    public void destroy()
    {
        SceneManager.LoadScene(0);
    }
    
   
}
