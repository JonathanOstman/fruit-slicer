﻿using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public float startForce = 13f;

    public static int missedFruit = 1;

    static Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Blade blade = col.GetComponent<Blade>();
            Vector3 direction = ((blade != null) ? blade.Velocity : col.transform.position - transform.position).normalized; 

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);

            ScoreScript.scoreValue += 5;
            if (ScoreScript.scoreValue > ScoreScript.highScore)
            {
                PlayerPrefs.SetInt(ScoreScript.highScoreKey, ScoreScript.scoreValue);
            }
        }
    }

    void OnBecameInvisible()
    {
        missedFruit += 1;
        Debug.Log("Missed");
    }

}
