using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinShower : MonoBehaviour
{

   

    private void Start()
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = "" + PlayerPrefs.GetInt("Scoree");
    }

    private void OnEnable()
    {
        Text text = gameObject.GetComponent<Text>();
        text.text = "" + PlayerPrefs.GetInt("Scoree");

    }


}
