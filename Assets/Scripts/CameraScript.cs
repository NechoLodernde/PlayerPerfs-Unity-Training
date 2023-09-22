using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    string key1 = "MyFirstKey";
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(key1, value);

        Debug.Log(PlayerPrefs.GetInt(key1).ToString());
    }

}
