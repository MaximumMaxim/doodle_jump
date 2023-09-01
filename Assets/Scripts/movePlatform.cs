using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    public float minX, maxX, speed;
    public float jumpForce = 10f;

    private bool right =true;
    
    void Update()
    {
        if(right&& transform.position.x < maxX)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (right)
        {
            right = false;
        }
        else if(!right&& transform.position.x > minX)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (!right)
        {
            right=true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && collision.transform.name == "bestStas")
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }

}
