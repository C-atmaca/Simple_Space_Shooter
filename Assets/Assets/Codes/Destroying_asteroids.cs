using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroying_asteroids : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    GameObject GameControl;
    Game_control control;

    void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("GameController");
        control = GameControl.GetComponent<Game_control>();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Area" && col.tag != "Border") 
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            control.ScoreGain(10);
        }
        if (col.tag == "Player" && col.tag != "Border")
        {
            Instantiate(playerExplosion, col.transform.position, col.transform.rotation);
            control.GameOver();
        }
        
    }

}
