using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;
    public AudioClip clickSound;
    private readonly string startSceneName = "StartScene";
    private readonly string settingsSceneName = "SettingsScene";

    public void GoToSettings()
    {
        SceneManager.LoadScene(settingsSceneName);
    }
    
    public void GoToStart()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();  
#endif
    }

    public void ButtonClicked()
    {
        bool sfxState = SfxHandler.SfxInstance._sfxState;
        if (sfxState)
        {
            SfxHandler.SfxInstance.SetClip(clickSound);
        }
    }
}
