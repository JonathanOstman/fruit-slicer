using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public AudioMixer audioMixer;

	// Use this for initialization
	void Start () {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volumeLevel", 0));
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("graphics", 2));
        Screen.fullScreen = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
    }
}
