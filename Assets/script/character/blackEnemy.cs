using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackEnemy : enemy
{
    public GameObject shortgunObj;
    public void Start()
    {
        lookAtPlayer();
    }
    protected override void Update()
    {       
        if (HP <= 0)
        {
            bool[] shortgunItem = { true, false, false, false, false };
            int random = Random.Range(0, 5);
            
            if (shortgunItem[random])
            {
                Instantiate(shortgunObj, transform.position, Quaternion.identity);
            }
        }
            
        base.Update();
    }

}
