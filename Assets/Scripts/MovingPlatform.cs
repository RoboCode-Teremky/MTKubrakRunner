using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float CurrentSpeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.back*CurrentSpeed*Time.deltaTime);
    }

}
