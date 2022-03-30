using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotateSpeed = 300;
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime,
            Space.World);
    }
    
}
