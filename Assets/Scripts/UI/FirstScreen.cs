using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstScreen : MonoBehaviour
{
    [SerializeField] List<Button> Buttons = new List<Button>(); 

    void Start()
    {
    
        int ver = PlayerPrefs.GetInt("Version",0);
        Debug.Log("THIS SYSTEM RUNNING ON" + Application.systemLanguage);
        if (Application.systemLanguage == SystemLanguage.Ukrainian)
        {
             Ua();
        }
        else
        if (Application.systemLanguage == SystemLanguage.English)
        {
            En();
        }
        else
        {
            En();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            SceneManager.UnloadSceneAsync(0);
        }
      


    }



    void En()
    {
        PlayerPrefs.SetInt("Version", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    void Ua()
    {
        PlayerPrefs.SetInt("Version", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }
}
