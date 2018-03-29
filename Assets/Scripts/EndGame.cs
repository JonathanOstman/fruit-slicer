using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    float timeLeft = 5f;

    Rigidbody2D rb;
    GameObject target;


    void Start()
    {
    }

    void Update()
    {
        //       timeLeft -= Time.deltaTime;
        //       if (timeLeft < 0)
        //       {
        //           GameOver();
        //           Debug.Log("Game over");
        //       }
        if (GameObject.FindGameObjectWithTag("Fruit"))
        {
            rb = GameObject.FindGameObjectWithTag("Fruit").GetComponent<Rigidbody2D>();
        }
        NoFruits();
    }

    void NoFruits()
    {
        if (Fruit.missedFruit > 3)
        {
            PlayerPrefs.SetInt("lastScore", ScoreScript.scoreValue);
            GameOver();
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (rb != null)
        {
            if (col.tag == "Fruit" && rb.velocity.y < -0.1f)
            {
                Debug.Log(Fruit.missedFruit);
                Fruit.missedFruit += 1;
            }
        }
    }

    void GameOver()
    {
        
        SceneManager.LoadScene(3);
    }
}
