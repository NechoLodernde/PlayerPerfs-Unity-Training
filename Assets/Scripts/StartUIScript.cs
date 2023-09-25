using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUIScript : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField roleField;
    public TMP_Dropdown genderField;

    public AudioClip clickSound;
    private readonly string menuSceneName = "MainMenuScene";
    
    public void AcceptSave()
    {
        var dropdown = genderField.transform.GetComponent<TMP_Dropdown>();
        int index = dropdown.value;
        List<TMP_Dropdown.OptionData> genderOptions = dropdown.options;
        string pName = nameField.text.ToString();
        string pRole = roleField.text.ToString();
        string pGender = genderOptions[index].text.ToString();
        if(pName.Equals("") || pRole.Equals(""))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            PlayerPrefs.SetString("PersonName", pName);
            PlayerPrefs.SetString("PersonRole", pRole);
            PlayerPrefs.SetString("PersonGender", pGender);
            SceneManager.LoadScene(menuSceneName);
        }
    }

    public void CancelSave()
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
