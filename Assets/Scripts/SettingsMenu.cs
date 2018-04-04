using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Dropdown resolutionDropdown;
    public Dropdown graphicDropdown;
    public Toggle fullscreenToggle;

    float volumeLevel;
    string volumeKey = "volumeLevel";

    int resolutionIndex;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update () {
        volumeLevel = PlayerPrefs.GetFloat(volumeKey, 0);
        audioMixer.SetFloat("volume", volumeLevel);
        volumeSlider.value = volumeLevel;
        graphicDropdown.value = PlayerPrefs.GetInt("graphics", 2);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;

        
    }
    public void SetResolutionIndex(int resolutionIndex1)
    {
        resolutionIndex = resolutionIndex1;
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(volumeKey, volume);

        audioMixer.SetFloat("volume", volumeLevel);
    }

    public void SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("graphics", qualityIndex);

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("graphics", 2));
    }

    public void SetFullScreen(bool isFullscreen)
    {
        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);

        Screen.fullScreen = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
