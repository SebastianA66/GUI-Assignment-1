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
            //Options hidden
            showOption = false;
            //mainMenu visable
            mainMenu.SetActive(true);
            // Options hidden
            optionMenu.SetActive(false);
            return false;

        }
        else
        {
            // Options visable
            showOption = true;
            // mainMenu hidden
            mainMenu.SetActive(false);
            // Options visable
            optionMenu.SetActive(true);
            // Attaching the audio to the volume slider
            volSlider = GameObject.Find("AudioSlider").GetComponent<Slider>();
            // Attaching the brightness to the brightness slider
            brightSlider = GameObject.Find("Brightness").GetComponent<Slider>();
            // Attaching the resolution to the dropdown bar
            resDropdown = GameObject.Find("Resolution").GetComponent<Dropdown>();
            // Audio adjustable by volume slider
            volSlider.value = mainAudio.volume;
            // Brightness adjustable by brightness slider
            brightSlider.value = dirLight.intensity;
            // Ambient adjustable by ambient slider
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
        // Options hidden
        showOption = false;
        // mainMenu visable
        mainMenu.SetActive(true);
        // Options hidden
        optionMenu.SetActive(false);
        return;
    }
}
