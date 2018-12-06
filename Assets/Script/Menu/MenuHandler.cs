using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject mainMenu, optionMenu;
    public bool showOption;
    public Light dirLight;
    public AudioSource mainAudio;
    public Slider volSlider;
    public Slider brightSlider;
    public Slider ambientSlider;
    public Vector2[] res = new Vector2[7];
    public int resIndex;
    public bool isFullScreen;
    public Dropdown resDropdown;

   
    void Start()
    {
        // Find Audio
        mainAudio = GameObject.Find("Audio Source").GetComponent<AudioSource>(); 
        // Find light
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();



        return;
    }
    private void Awake()
    {
        // Find Audio for slider
        volSlider.value = PlayerPrefs.GetFloat("Audio Source");
        // Find brightness for slider
        brightSlider.value = PlayerPrefs.GetFloat("Directional Light");
    }

    

    public void LoadGame()
    {
        PlayerPrefs.SetFloat("Audio Source", mainAudio.volume);
        PlayerPrefs.SetFloat("Directional Light", dirLight.intensity);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        // Closes the game
        Application.Quit();

        // Enables the game to close during the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void ToggleOption()
    {
        // Switch between opeions being on and off
        OptionToggle();
    }
    bool OptionToggle()
    {
        // if options are on
        if (showOption)
        {

            showOption = false;
            mainMenu.SetActive(true);
            optionMenu.SetActive(false);
            return false;

        }
        else
        {
            showOption = true;
            mainMenu.SetActive(false);
            optionMenu.SetActive(true);
            volSlider = GameObject.Find("AudioSlider").GetComponent<Slider>();
            brightSlider = GameObject.Find("Brightness").GetComponent<Slider>();
            resDropdown = GameObject.Find("Resolution").GetComponent<Dropdown>();
            volSlider.value = mainAudio.volume;
            brightSlider.value = dirLight.intensity;
            ambientSlider.value = RenderSettings.ambientIntensity;
            return true;
        }
    }
    public void Volume()
    {
        mainAudio.volume = volSlider.value;
    }
    public void Brightness()
    {
        dirLight.intensity = brightSlider.value;

    }
    public void Ambient()
    {
        RenderSettings.ambientIntensity = ambientSlider.value;
    }
    public void Resolution()
    {
        resIndex = resDropdown.value;
        Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
    }
    public void Back()
    {
        showOption = false;
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
        return;
    }
}
