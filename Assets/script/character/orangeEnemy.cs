using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeEnemy : enemy
{
    GameObject player;
    public void Start()
    {
        player = GameObject.Find("spaceship");
        lookAtPlayer();
    }

    protected override void Update()
    {
        base.Update();
        float rotationSpeed = 30;

        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);

    }
}
