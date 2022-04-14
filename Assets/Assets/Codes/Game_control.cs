using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_control : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 randomPos;
    public float minSec, maxSec, creFrequency, firstDelay;
    int score;
    bool gameOverControl = false;
    bool restartControl = false;
    float exp = 200;
    int stage = 1;
    Astetoid_movement asteroidMov;

    public Text text;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;


    void Start()
    {
        text.text = "Score:" + score;
        text5.text = "Stage" + stage;
        StartCoroutine(Create());
        asteroidMov = asteroid.GetComponent<Astetoid_movement>();
        asteroidMov.speed = 3;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //&& restartControl == true)
        {
            SceneManager.LoadScene("Level1");
            asteroidMov.speed = 3;
        }
    }
    IEnumerator Create() 
    {
        yield return new WaitForSeconds(firstDelay);

        while (true) 
        {
            if (score == exp)
            {
                asteroidMov.speed += 1;
                exp += 200;
                stage++;
                text5.text = "Stage" + stage;
                //Debug.Log("");

            }

            for (int i = 0; i < 10; i++)
            {


                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 1, randomPos.z);
                Instantiate(asteroid, vec, Quaternion.identity);

                yield return new WaitForSeconds(creFrequency);
            }
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));

            if (gameOverControl)
            {
                //restartControl = true;
                break;
            }

            
        }
       
       
        
    }
    

    public void ScoreGain(int scoreIncoming)
    {
        score += scoreIncoming;
        text.text = "Score:" + score;
        //Debug.Log(score);
    }
  
    public void GameOver() 
    {
        text.text = "";
        text2.text = "GameOver";
        text3.text = "Press R to Restart";
        text4.text = "Final Score:" + score;
        text5.text = "";
        asteroidMov.speed = 3;
        //Debug.Log("GameOver");
        //Debug.Log("Final Score:" + score);
        gameOverControl = true;
    }

}
