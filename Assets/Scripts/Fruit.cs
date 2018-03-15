using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public float startForce = 13f;

    public static int missedFruit = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);


        //ScoreScript.score.text = "Poäng : " + ScoreScript.scoreValue.ToString();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Blade blade = col.GetComponent<Blade>();
            Vector3 direction = ((blade != null) ? blade.velocity : col.transform.position - transform.position).normalized; 

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);

            ScoreScript.scoreValue += 5;
            //ScoreScript.score.text = ScoreScript.scoreValue.ToString();
            //Debug.Log(ScoreScript.scoreValue);
            if (ScoreScript.scoreValue > ScoreScript.highScore)
            {
                PlayerPrefs.SetInt(ScoreScript.highScoreKey, ScoreScript.scoreValue);
                Debug.Log("Highscore is:" + ScoreScript.highScore);
            }
        }
    }

    void OnBecameInvisible()
    {
        missedFruit += 1;
        Debug.Log("Missed");
    }

}
