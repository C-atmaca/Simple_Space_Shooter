using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_Code : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    GameObject GameControl;
    Game_control control;
    public GameObject player;
    bool dead = false;

    void Start()
    {
        GameControl = GameObject.FindGameObjectWithTag("GameController");
        control = GameControl.GetComponent<Game_control>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(player);
            Destroy(col.gameObject);
            Instantiate(explosion, col.transform.position, col.transform.rotation);
            if (dead == false)
            {
                Instantiate(playerExplosion, player.transform.position, player.transform.rotation);
                dead = true;
            }
            

            control.GameOver();
        }
    }
}
