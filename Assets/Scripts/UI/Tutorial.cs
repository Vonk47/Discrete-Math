using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject Timer;
    [SerializeField] Text timerText;
    [SerializeField] Button but;
    [SerializeField] Text LevelText;
    [SerializeField] Text score;

    private void Start()
    {
        but.onClick.AddListener(continueToTheGame);
    }


    void continueToTheGame()
    {
        Animation anim = gameObject.GetComponent<Animation>();
        anim.Play();
        Timer.SetActive(true);
        timerText.gameObject.SetActive(true);
        LevelManager.isTutorial = false;
        LevelText.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        Invoke("DisableGameObj", 1.1f);
    }
    void DisableGameObj()
    {
        gameObject.SetActive(false);
    }

 
}
