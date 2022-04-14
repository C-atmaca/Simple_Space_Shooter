using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Explosion : MonoBehaviour
{
    public float destDelay;
    void Start()
    {
        Destroy(gameObject, destDelay);
    }

    
   
}
