using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    

    public void MainScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
