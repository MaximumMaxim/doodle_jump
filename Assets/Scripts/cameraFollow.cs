using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollow : MonoBehaviour
{
    public player player;
    public Transform target;
    
    void LateUpdate()
    {
        if (target)
        {
            if(target.position.y > transform.position.y)
            {
                Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
                transform.position = newPos;
            } 

        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(0);
    }

    

}
