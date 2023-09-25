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
    public GameObject introPanel; 
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;
    public TMP_Text pNameText;
    public TMP_Text pRoleText;
    public TMP_Text pGenderText;
    public AudioClip clickSound;
    
    private readonly string startSceneName = "StartScene";
    private readonly string settingsSceneName = "SettingsScene";
    private readonly float notifTimer = 5f;

    private void Start()
    {
        if(PlayerPrefs.HasKey("PersonName") &&
            PlayerPrefs.HasKey("PersonRole") &&
            PlayerPrefs.HasKey("PersonGender"))
        {
            introPanel.SetActive(true);
            pNameText.text = PlayerPrefs.GetString("PersonName");
            pRoleText.text = PlayerPrefs.GetString("PersonRole");
            pGenderText.text = PlayerPrefs.GetString("PersonGender");
            StartCoroutine(SpawnIntro());
        }
    }

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

    IEnumerator SpawnIntro()
    {
        yield return new WaitForSeconds(notifTimer);
        introPanel.SetActive(false);
    }
}
