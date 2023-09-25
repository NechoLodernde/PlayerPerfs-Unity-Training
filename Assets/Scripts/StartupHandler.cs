using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupHandler : MonoBehaviour
{
    private readonly string mainMenuName = "MainMenuScene";

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(mainMenuName);    
    }

    
}
