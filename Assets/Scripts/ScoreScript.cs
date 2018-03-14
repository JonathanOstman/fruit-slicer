using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    public Text score;

	// Update is called once per frame
	void Update () {
        score.text = scoreValue.ToString();
	}
}
