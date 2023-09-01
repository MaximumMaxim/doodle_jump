using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class bee : MonoBehaviour
{
 
    public float speed;
    public float speedDistance;
    public float speedUP;
    public float speedDistanceUP;
    private bool alive = true;

    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (alive)
        {
            float xOffset = Mathf.Sin(Time.time * speed) * speedDistance;
            float yOffset = Mathf.Sin(Time.time * speedUP) * speedDistanceUP;

            Vector3 newPosition = originalPosition + new Vector3(xOffset, 0f, 0f) + new Vector3(0f, yOffset, 0f);
            transform.position = newPosition;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null&&collision.transform.name == "bestStas")
        {
            Destroy(collision.collider);
            restart();

        }
        else if(collision.gameObject.tag == "bullet")
        {
            alive = false;
            Destroy(gameObject, 1f);
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
