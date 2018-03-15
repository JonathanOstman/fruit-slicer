using UnityEngine;
using TMPro;


public class UpdateHighscore : MonoBehaviour {

    private TextMeshProUGUI highScoreText;

    // Update is called once per frame
    void Update () {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScoreText.text = "Highscore: " + ScoreScript.highScore;

    }
}
