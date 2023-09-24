using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIScript : MonoBehaviour
{
    public AudioClip clickSound;
    private string menuSceneName = "MainMenuScene";
    
    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void ButtonClicked()
    {
        SfxHandler.SfxInstance.sfx.clip = clickSound;
        SfxHandler.SfxInstance.sfx.Play();
    }
}
