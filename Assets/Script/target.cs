using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float spinspeed;


   
    void Update()
    {
        transform.Rotate(Vector3.up * spinspeed * Time.deltaTime, Space.World);
    }
}

// add