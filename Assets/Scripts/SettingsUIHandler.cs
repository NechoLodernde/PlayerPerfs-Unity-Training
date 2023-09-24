using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsUIHandler : MonoBehaviour
{
    public AudioClip clickSound;

    [SerializeField] private Slider sfxSlider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Toggle sfxToggle = null;
    [SerializeField] private Toggle musicToggle = null;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void ButtonClicked()
    {
        SfxHandler.SfxInstance.sfx.clip = clickSound;
        SfxHandler.SfxInstance.sfx.Play();
    }
}
