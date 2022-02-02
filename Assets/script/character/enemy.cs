using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : character
{
    private gameManager manager;

    public void Start()
    {
        transform.Rotate(0, 0, 270);
    }
    virtual protected void Update()
    {
        move();
        if (HP <= 0)
        {
            manager.score += score;
            Destroy(gameObject);
        }
    }

    public void move()
    {
        transform.position += transform.TransformDirection(Vector3.right * speed * Time.deltaTime);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "bullet")
        {
            manager = FindObjectOfType<gameManager>();
            
            
            HP -= collision.gameObject.GetComponent<bullet>().damage;
            Destroy(collision.gameObject);

        }
        if ( collision.gameObject.name == "deadZone")
        {
           
            Destroy(gameObject);
        }
        
    }

    public void lookAtPlayer()
    {
        Vector3 player = GameObject.Find("spaceship").transform.position - transform.position;

        transform.right = player;
    }
}
