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

    private readonly string mainMenuName = "MainMenuScene";

    // Start is called before the first frame update
    private void Start()
    {
        LoadValues();
    }

    public void SfxVolume()
    {
        SfxHandler.SfxInstance.SetVolume(sfxSlider.value);
    }

    public void MusicVolume()
    {
        MusicHandler.MusicInstance.SetVolume(musicSlider.value);
    }

    public void SfxToggle()
    {
        Debug.Log("Sfx Toggle is: " + sfxToggle.isOn.ToString());
        SfxHandler.SfxInstance.SetState(sfxToggle.isOn.ToString());
    }

    public void MusicToggle()
    {
        Debug.Log("Music Toggle is: " + musicToggle.isOn.ToString());
        MusicHandler.MusicInstance.SetState(musicToggle.isOn.ToString());
    }

    public void CancelChanges()
    {
        SfxHandler.SfxInstance.SetVolume();
        MusicHandler.MusicInstance.SetVolume();
        SfxHandler.SfxInstance.SetState();
        MusicHandler.MusicInstance.SetState();
        SceneManager.LoadScene(mainMenuName);
    }

    public void AcceptChanges()
    {
        float sfxValue = sfxSlider.value;
        float musicValue = musicSlider.value;
        string sfxState = sfxToggle.isOn.ToString();
        string musicState = musicToggle.isOn.ToString();
        PlayerPrefs.SetFloat("SfxVolume", sfxValue);
        PlayerPrefs.SetFloat("MusicVolume", musicValue);
        PlayerPrefs.SetString("SfxState", sfxState);
        PlayerPrefs.SetString("MusicState", musicState);
        SfxHandler.SfxInstance.SetVolume();
        MusicHandler.MusicInstance.SetVolume();
        SfxHandler.SfxInstance.SetState();
        MusicHandler.MusicInstance.SetState();
        SceneManager.LoadScene(mainMenuName);
    }

    public void LoadValues()
    {
        if(PlayerPrefs.HasKey("SfxVolume") &&
            PlayerPrefs.HasKey("MusicVolume") &&
            PlayerPrefs.HasKey("SfxState") &&
            PlayerPrefs.HasKey("MusicState"))
        {
            float sfxValue = PlayerPrefs.GetFloat("SfxVolume");
            float musicValue = PlayerPrefs.GetFloat("MusicVolume");
            string sfxState = PlayerPrefs.GetString("SfxState");
            string musicState = PlayerPrefs.GetString("MusicState");
            sfxSlider.value = sfxValue;
            musicSlider.value = musicValue;
            
            if (sfxState.Equals("True"))
            {
                sfxToggle.isOn = true;
            }
            else
            {
                sfxToggle.isOn = false;
            }

            if (musicState.Equals("True"))
            {
                musicToggle.isOn = true;
            }
            else
            {
                musicToggle.isOn = false;
            }

            SfxHandler.SfxInstance.SetVolume(sfxValue);
            SfxHandler.SfxInstance.SetState(sfxState);
            MusicHandler.MusicInstance.SetVolume(musicValue);
            MusicHandler.MusicInstance.SetState(musicState);
        }
        else
        {
            sfxSlider.value = -15f;
            musicSlider.value = -15f;
            sfxToggle.isOn = true;
            musicToggle.isOn = true;
            SfxHandler.SfxInstance.SetVolume(-15f);
            SfxHandler.SfxInstance.SetState("True");
            MusicHandler.MusicInstance.SetVolume(-15f);
            MusicHandler.MusicInstance.SetState("True");
        }
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
