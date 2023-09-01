using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPlatfrom : MonoBehaviour
{
    public float jumpForce = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if(rb.velocity.y <= 0f && collision.transform.name == "bestStas")
        {
            if (rb != null)
            {        
                Destroy(gameObject);
            }
        }

        
    }
}
