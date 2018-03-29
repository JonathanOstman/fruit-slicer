using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastScore : MonoBehaviour {

    private TextMeshProUGUI score;

	// Use this for initialization
	void Start () {
        score = GetComponent<TextMeshProUGUI>();
        score.text = "Score: " + PlayerPrefs.GetInt("lastScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
