using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class breakPlatform : MonoBehaviour
{
    public static bool broke = false;
    public float jumpForce = 10f;
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

                Destroy(gameObject, 0.2f);
            }
        }
    }

}
