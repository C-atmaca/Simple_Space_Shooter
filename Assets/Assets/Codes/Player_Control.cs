using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    Rigidbody physic;
    float horizontal;
    float vertical;
    Vector3 vec;
    public float speed;
    public float minX, minZ, maxX, maxZ;
    public float slope;
    float fireRate;
    public float fireDelay;
    public GameObject magazine;
    public Transform muzzle;
    AudioSource audio;


    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireRate)
        {
            fireRate = Time.time + fireDelay;
            Instantiate(magazine, muzzle.position, Quaternion.identity);
            audio.Play();
            //Debug.Log("fire");
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal, 0, vertical);

        physic.velocity = vec * speed;
        
        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * -slope);

        physic.position = new Vector3
            (
                Mathf.Clamp(physic.position.x, minX, maxX),
            1.0f,
                Mathf.Clamp(physic.position.z, minZ, maxZ)
            );

        
    }
   

}
