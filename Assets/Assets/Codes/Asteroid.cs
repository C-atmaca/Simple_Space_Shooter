using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    Rigidbody physic;
    public float speed;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        physic.angularVelocity = Random.insideUnitSphere * speed;
    }


}
