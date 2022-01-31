using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 0, damage=0; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed*transform.localScale.y * Time.deltaTime;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "spaceship")
        {
            
            Destroy(gameObject);
        }
    }
    
}
