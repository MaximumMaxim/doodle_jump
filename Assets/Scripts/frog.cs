using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class frog : MonoBehaviour
{

    public float speed;
    public float speedDistance = 6f;
    public float speedUP;
    public float speedDistanceUP;
    public float scaleXFactor = 1f;

    public float jumpForcePlayer = 15;

    private Vector3 originalPosition;
    private Vector3 lastPosition;
    private Vector3 originalScale;


    private bool enemyAlive = true;


    private void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
    }

    void Update()
    {      
        moveEnemy();
    }

    public void moveEnemy()
    {
       
        if (enemyAlive)
        {
            float xOffset = Mathf.Sin(Time.time * speed) * speedDistance;
            float yOffset = Mathf.Sin(Time.time * speedUP) * speedDistanceUP;

            Vector3 newPosition = originalPosition + new Vector3(xOffset, 0f, 0f) + new Vector3(0f, yOffset,0f);
            transform.position = newPosition;

            Vector3 direction = newPosition - lastPosition;
            lastPosition = newPosition;

            if (direction != Vector3.zero)
            {
                float newScaleX = direction.x > 0 ? -scaleXFactor : scaleXFactor;
                transform.localScale = new Vector3(newScaleX * originalScale.x, originalScale.y, originalScale.y);
            }
        }
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && (collision.transform.name == "bestStas"||collision.gameObject.tag == "bullet"))
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForcePlayer;
                rb.velocity = velocity;

                enemyAlive = false;

                Destroy(gameObject, 1f);
                
            }
        }
        else if(collision.gameObject.name == "bestStas"&&enemyAlive)
        {
            Destroy(collision.collider);
            restart();
        }

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
