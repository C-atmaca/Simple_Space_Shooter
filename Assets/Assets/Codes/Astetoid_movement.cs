using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astetoid_movement : MonoBehaviour
{
    Rigidbody physic;
    public float speed;
  

    public void Start()
    {
        physic = GetComponent<Rigidbody>();
        physic.velocity = transform.forward * -speed;

        
    }
    

}
