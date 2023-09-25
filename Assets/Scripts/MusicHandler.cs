using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that will handle music and GameObject inside the game
public class MusicHandler : MonoBehaviour
{
    // Create static object that can be referenced in other script
    // Initialized the get and set method
    public static MusicHandler MusicInstance { get; private set; }
    // Setup AudioSource for object is empty when first initialized
    public AudioSource music = null;
    // Will contain the volume value for music
    public float _musicVolume;
    // 
    public bool _musicState = true;
    // String that will hold Object ID, for multiple instance problem
    public string objectID;

    // Method that will run first before Start method
    private void Awake()
    {
        // Add Object ID to the instance with name + object position to string
        objectID = name + transform.position.ToString();
    }

    // Method that will run after Awake method and before first frame update
    void Start()
    {
        // Get the AudioSource component to the variable
        music = GetComponent<AudioSource>();
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<MusicHandler>().Length; i++)
        {
            // If the object not equal to this
            if (Object.FindObjectsOfType<MusicHandler>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<MusicHandler>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set music instance to be use in other scenes
        MusicInstance = this;
        // Call Method that will configure volume
        SetVolume();
        // Function to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }

    // Method that will setup the volume
    public void SetVolume()
    {
        // Condition to check if previous configuration exist using PlayerPrefs
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            // Contain the value from existing configuration
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            // Set the volume from AudioMixer with the key found in configuration
            music.outputAudioMixerGroup.audioMixer.SetFloat("musicVolume", Mathf.Min(0, musicVolume));
        }
        else
        {
            music.outputAudioMixerGroup.audioMixer.SetFloat("musicVolume", -20f);
        }
    }

    // Method that will setup the volume, accept one float parameter
    public void SetVolume(float number)
    {
        music.outputAudioMixerGroup.audioMixer.SetFloat("musicVolume", Mathf.Min(0, number));
    }

    public void SetState()
    {
        Debug.Log("Music Data is : " + PlayerPrefs.GetString("MusicState"));
        if (PlayerPrefs.HasKey("MusicState"))
        {
            string musicState = PlayerPrefs.GetString("MusicState");
            if (musicState.Equals("True"))
            {
                _musicState = true;
                music.UnPause();
            }
            else
            {
                _musicState = false;
                music.Pause();
            }
        }
        else
        {
            _musicState = true;
            music.UnPause();
        }
    }

    public void SetState(string toggleState)
    {
        Debug.Log("Music State is: " + toggleState);
        if (toggleState.Equals("True"))
        {
            _musicState = true;
            music.UnPause();
        }
        else
        {
            _musicState = false;
            music.Pause();
        }
    }
}
