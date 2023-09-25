using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIScript : MonoBehaviour
{
    public AudioClip clickSound;
    private readonly string menuSceneName = "MainMenuScene";
    
    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
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
