using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shit : MonoBehaviour
{
    public float speed;
    public float distALive;
  

    private void Start()
    {
        Destroy(gameObject, distALive); 
    }
    private void Update()
    {
        transform.Translate(Vector2.down * speed*Time.deltaTime);     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
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
