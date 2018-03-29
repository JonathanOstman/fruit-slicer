using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    public Text score;

    public static int highScore;
    public static string highScoreKey = "HighScore";


    // Update is called once per frame
    void Update () {
        score.text = scoreValue.ToString();
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
	}

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(highScoreKey);
    }
}
