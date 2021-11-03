using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button info;
    [SerializeField] Button exit;
    [SerializeField] Button infoBack;
    [SerializeField] Button retryButton;
    [SerializeField] Button backToMainButton;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject LosePopUp;
    [SerializeField] GameObject Level;
    [SerializeField] GameObject infoObj;
    [SerializeField] GameObject ParticleSys;
    [SerializeField] Animation MainMenuAnimation;
    [SerializeField] Animation LosePopUpAnim;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        startButton.onClick.AddListener(StartTheGame);
        info.onClick.AddListener(ShowInfo);
    //    exit.onClick.AddListener(ExitTheGame);
        infoBack.onClick.AddListener(BackToMenu);
        retryButton.onClick.AddListener(Retry);
        backToMainButton.onClick.AddListener(BackToMenu);
    }

    void StartTheGame()
    {
        ParticleSys.SetActive(false);
        MainMenuAnimation.Play("Tutor");
        Invoke("DisableMainMenu", 1.02f);
        Level.SetActive(true);
    }
    void ExitTheGame()
    {
        Application.Quit();
    }

    void ShowInfo()
    {
     
        infoObj.SetActive(true);
        ParticleSys.SetActive(false);
        MainMenuAnimation.Play("Tutor");
        Invoke("DisableMainMenu",1.02f);
    }

    void DisableMainMenu()
    {
        Menu.SetActive(false);
    }
    void BackToMenu()
    {

        Menu.transform.localPosition =new Vector3 (0, 0, 0);
            LosePopUpAnim.Play("1");
        Menu.SetActive(true);
        infoObj.SetActive(false);
        ParticleSys.SetActive(true);
        Invoke("DisableLosePopUp", 1.02f);

    }
    void DisableLosePopUp()
    {
        LosePopUp.SetActive(false);
        LosePopUp.transform.localPosition = new Vector3(0, 0, 0);
    }
    void Retry()
    {
        Level.SetActive(true);
        LosePopUp.SetActive(false);
    }

}
