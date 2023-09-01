using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bird : MonoBehaviour
{

    public GameObject shitPrefab;
    public Transform birdPosition;

    public float speed;
    public float speedDistance;
    public float speedScary = 3f;
    public float scaryDistance;
    private float scaleXFactor = 1f;
    
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Vector3 lastPosition;

    public float timeToShit;

    private void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
        StartCoroutine(TimeToShit());
    }

    private void Update()
    {     
        float xOffers = Mathf.Sin(Time.time * speed) * speedDistance;
        Vector3 newPosition =originalPosition + new Vector3(xOffers, 0, 0);
        transform.position = newPosition;

        Vector3 direction = newPosition - lastPosition;
        lastPosition = newPosition;

        if(direction != Vector3.zero) 
        {
            float newScaleX = direction.x > 0 ? scaleXFactor : -scaleXFactor;
            transform.localScale = new Vector3(newScaleX * originalScale.x, originalScale.y, originalScale.y);
        }
    }

    private IEnumerator TimeToShit()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToShit);      
            Vector3 newPosition = birdPosition.position + new Vector3(0,-1f,0);
            Instantiate(shitPrefab, newPosition, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if(rb != null&&(collision.gameObject.tag == "Player"||collision.gameObject.tag == "bullet"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            speed = +speedScary;
            speedDistance += scaryDistance;
            Destroy(gameObject, 2f);
        }
    }
}
