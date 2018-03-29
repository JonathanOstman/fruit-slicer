using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
        Fruit.missedFruit = 0;
        ScoreScript.scoreValue = 0;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        Fruit.missedFruit = 0;
        ScoreScript.scoreValue = 0;
    }
}
