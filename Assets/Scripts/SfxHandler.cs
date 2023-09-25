using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that will handle sound effect and GameObject inside the game
public class SfxHandler : MonoBehaviour
{
    // Create static object that can be referenced in other script
    // Initialized the get and set method
    public static SfxHandler SfxInstance { get; private set; }
    // Setup AudioSource for object is empty when first initialized
    public AudioSource sfx = null;
    // Will contain the volume value for sound effect
    public float _sfxVolume;
    //
    public bool _sfxState = true;
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
        sfx = GetComponent<AudioSource>();
        // Create for loop for iterating all object of same type
        for (int i = 0; i < Object.FindObjectsOfType<SfxHandler>().Length; i++)
        {
            // If the object not equal to this
            if (Object.FindObjectsOfType<SfxHandler>()[i] != this)
            {
                // If the object have the same ID, then destroy the new instance
                if (Object.FindObjectsOfType<SfxHandler>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        // Set sound effect instance to be use in other scenes
        SfxInstance = this;
        // Call Method that will configure volume
        SetVolume();
        // Function to not destroy the object onload/switch scene
        DontDestroyOnLoad(gameObject);
    }

    // Method that will setup the volume
    public void SetVolume()
    {
        // Condition to check if previous configuration exist using PlayerPrefs
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            // Contain the value from existing configuration
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
            // Set the volume from AudioMixer with the key found in configuration
            sfx.outputAudioMixerGroup.audioMixer.SetFloat("sfxVolume", Mathf.Min(0, sfxVolume));
        }
        else
        {
            sfx.outputAudioMixerGroup.audioMixer.SetFloat("sfxVolume", -20f);
        }
    }

    // Method that will setup the volume, accept one float parameter
    public void SetVolume(float number)
    {
        sfx.outputAudioMixerGroup.audioMixer.SetFloat("sfxVolume", Mathf.Min(0, number));
    }

    public void SetState()
    {
        if (PlayerPrefs.HasKey("SfxState"))
        {
            string sfxState = PlayerPrefs.GetString("SfxState");
            if (sfxState.Equals("True"))
            {
                _sfxState = true;
            }
            else
            {
                _sfxState = false;
            }
        }
        else
        {
            _sfxState = true;
        }
    }

    public void SetState(string toggleState)
    {
        if (toggleState.Equals("True"))
        {
            _sfxState = true;
        }
        else
        {
            _sfxState = false;
        }
    }

    // Method that will configure current audio clip
    public void SetClip(AudioClip audioClip)
    {
        // Change current audio clip with parameter audio clip
        sfx.clip = audioClip;
        // Play current audio clip
        sfx.Play();
    }
}
