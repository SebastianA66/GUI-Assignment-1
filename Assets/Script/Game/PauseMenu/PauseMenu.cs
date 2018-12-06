using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenu, optionMenu;
    public bool showMenu;
    public AudioSource soundAudio;
    public Light dirLight;
    public Slider ambientSlider;
    public Slider soundSlider;
    public Slider lightSlider;
    public Vector2[] res = new Vector2[7];
    public int resIndex;
    public bool isFullScreen;
    public Dropdown resDropdown;
    public GameObject cam1;
    public GameObject mainCam;
    public GameObject player;


    // Use this for initialization
    void Start()
    {

        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        //soundAudio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
        //soundSlider.value = PlayerPrefs.GetFloat("Audio Source");
        lightSlider.value = PlayerPrefs.GetFloat("Directional Light");


        return;

    }

    // Update is called once per frame

    void Update()
    {
        // When escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pause the game
            Pause();
        }
    }
    //When the game is resumed
    public void Resume()
    {
        // pause menu is false
        pauseMenu.SetActive(false);
        // options menu is false
        optionMenu.SetActive(false);
        // real time is resumed
        Time.timeScale = 1f;
        // enable the controller
        player.GetComponent<Controller>().enabled = true;
        // mouseLook is enabled
        player.GetComponent<MouseLook>().enabled = true;
        mainCam.GetComponent<MouseLook>().enabled = true;
        GameIsPaused = false;


    }
    // When the game is paused
    void Pause()
    {
        // Pause menu is visable
        pauseMenu.SetActive(true);
        // options menu is hidden 
        optionMenu.SetActive(false);
        // real time is paused
        Time.timeScale = 0f;

        // disable the controller
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        mainCam.GetComponent<MouseLook>().enabled = false;
        GameIsPaused = true;
        // cursor is able to be seen
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;



    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetFloat("Audio Source", soundAudio.volume);
        PlayerPrefs.SetFloat("Directional Light", dirLight.intensity);
        SceneManager.LoadScene(0);
    }
    public void Exitmenu()
    {
        // Exits game in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ToggleOption()
    {
        // toggles the options when pressed
        OptionToggle();
    }
    public void Volume()
    {
        // Attaches volume to slider
        soundAudio.volume = soundSlider.value;
    }
    public void Brightness()
    {
        // attaches brightness to slider
        dirLight.intensity = lightSlider.value;

    }
    bool OptionToggle()
    {
        if (showMenu)
        {
            showMenu = false;
            pauseMenu.SetActive(true);
            optionMenu.SetActive(false);
            return false;

        }
        else
        {

            showMenu = true;

            pauseMenu.SetActive(false);
            optionMenu.SetActive(true);
            soundSlider = GameObject.Find("SoundSlider").GetComponent<Slider>();
            lightSlider = GameObject.Find("BrightnessSlider").GetComponent<Slider>();

            soundSlider.value = soundAudio.volume;
            lightSlider.value = dirLight.intensity;


            return true;
        }

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
        showMenu = false;
        pauseMenu.SetActive(true);
        optionMenu.SetActive(false);
        return;
    }
}
