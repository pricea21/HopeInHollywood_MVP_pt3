using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public GameObject instructionsUI;
    public GameObject[] GameUI;
    public GameObject pauseMenu;
    public GameObject volumeControls;
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject pauseButton;
    public static bool GameIsPaused = false;
    

    void Update()
    {
        
    }


    public void Exit()
    {
        Time.timeScale = 1f;
        instructionsUI.SetActive(false);
        volumeControls.SetActive(false);
        startButton.SetActive(true);
        settingsButton.SetActive(true);
        pauseButton.SetActive(true);
    }

    public void VolumeControl()
    {
        instructionsUI.SetActive(false);
        startButton.SetActive(false);
        pauseMenu.SetActive(false);
        settingsButton.SetActive(true);
        volumeControls.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToInstructions()
    {
        volumeControls.SetActive(false);
        instructionsUI.SetActive(true);
    }

    public void SettingsButton()
    {
        instructionsUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
    }
}

