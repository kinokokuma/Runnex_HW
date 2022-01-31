using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{

    public int speed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * speed * transform.localScale.y * Time.deltaTime;
    }
}
