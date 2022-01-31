using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character
{
    // Start is called before the first frame update

    public bool shotgun = false, haveShotgun = false, shootCoolDown = false;
    public bool invisible = false;
    public GameObject bullet, shotgunBullet;
    public gameManager manager;

    void Start()
    {
        manager = FindObjectOfType<gameManager>();
        transform.position = new Vector3(spawnPoint.x, spawnPoint.y, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if(!shootCoolDown && Input.GetKeyDown(KeyCode.Space))
        {
            shootCoolDown = true;
            shootBullet();
            
           

        }

        if(Input.GetKeyDown(KeyCode.Tab)&& haveShotgun)
        {
            shotgun = !shotgun;
        }
        else if(!haveShotgun)
        {
            shotgun = false;
        }
        

        
    }

    public void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }

    public void shootBullet()
    {
        if (shotgun)
        {
            for (int i = -3; i <= 3; i++)
            {
                GameObject newBullet= Instantiate(shotgunBullet, transform.position , Quaternion.identity);
                newBullet.transform.Rotate( 0,0,25 * i);
            }
            StartCoroutine(coolDownBullet(0.5f));
        }
        else
        {
            Instantiate(bullet, transform.position , Quaternion.identity);
            StartCoroutine(coolDownBullet(0.25f));
        }
        
    } 

    IEnumerator coolDownBullet(float cd)
    {
        yield return new WaitForSeconds(cd);
        shootCoolDown = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "enemy"&&!invisible)
        {
            manager.life -= 1;
            if (manager.life >= 0)
            {
                manager.lifeIcon[manager.life].color = Color.black;
            }
            invisible = true;
            haveShotgun = false;
            Destroy(collision.gameObject);
            StartCoroutine(coolDownInvisible());
        }
        if(collision.gameObject.tag == "item" )
        {
            
            haveShotgun = true;
            Destroy(collision.gameObject);
            
        }
    }
    IEnumerator coolDownInvisible()
    {
        yield return new WaitForSeconds(3);
        
        invisible = false;
    }
}
