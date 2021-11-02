using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Slider timer;
    [SerializeField] Text timerText;
    [SerializeField] GameObject losePopUp;
    [SerializeField] GameObject plusOneObj;
    [SerializeField] Text charA;
    [SerializeField] Text charB;
    [SerializeField] Text operatorText;
    [SerializeField] Text textValueA;
    [SerializeField] Text textValueB;
    [SerializeField] Text Score;
    [SerializeField] Text Level;
    [SerializeField] Text minusA;
    [SerializeField] Text minusB;
    [SerializeField] AnimationClip startAnimation;
    [SerializeField] AnimationClip popUpAnimation;
    [SerializeField] Sprite good, bad;
    Animation anim;
    Image currentButtonImage, nextButtonImage;
    Sprite oldSprite;
    enum OperationState
    {
        or,
        and,
        implication,
        StrongDisunction,
        type1,
        type2,
        type3
    }
    OperationState operationState;

    char a, b;
    char oper;
    int valueA, valueB;
    string operators = "^V";
    string operators2 = "→⊕";
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    int score;
    int level = 1;
    int trueLevel = 1;
    int levelCounter=5;
    public static bool isTutorial=true;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.clip = startAnimation;
        GenerateExampleB();


    }


    #region [example A ]
    void GenerateExampleA()
    {
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();

        int minus1 = Random.Range(0, 2);
        int minus2 = Random.Range(0, 2);

        if (minus1 == 1)
        {
            minusA.gameObject.SetActive(true);
        }
        else
        {
            minusA.gameObject.SetActive(false);

        }
        if (minus2 == 1)
        {
            minusB.gameObject.SetActive(true);
        }
        else
        {
            minusB.gameObject.SetActive(false);

        }

        a = alphabet[Random.Range(0, alphabet.Length)];
        b = alphabet[Random.Range(0, alphabet.Length)];
        if (a == b)
        {
            b = alphabet[Random.Range(0, alphabet.Length)];
        }
        oper = operators[Random.Range(0, operators.Length)];
        charA.text = a + "";
        charB.text = b + "";
        operatorText.text = oper + "";
        valueA = Random.Range(0, 3);
        if (valueA == 2)
        {
            textValueA.gameObject.SetActive(false);
        }
        else
        {
            textValueA.gameObject.SetActive(true);
        }
        valueB = Random.Range(0, 2);
        textValueA.text = valueA + "";
        textValueB.text = valueB + "";
        if (minus1 == 1 && valueA==1)
        {
            valueA = 0;
        } else
        if (minus1 == 1 && valueA == 0)
        {
            valueA = 1;
        }

        if (minus2 == 1 && valueB == 1)
        {
            Debug.Log("CHANGED");
            valueB = 0;
        } else
        if (minus2 == 1 && valueB == 0)
        {
            Debug.Log("CHANGED 2");
            valueB = 1;
        }

        Text t1 = button1.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t2 = button2.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t3 = button3.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t4 = button4.transform.GetChild(0).gameObject.GetComponent<Text>();
        t1.text = "0";
        t2.text = "1";
        t3.text = a + "";
        t4.text = b + "";

        if (oper.ToString() == "V")
            operationState = OperationState.or;
        else operationState = OperationState.and;

        CheckOperator();

    }

    #endregion

    #region [example B]
    void GenerateExampleB()
    {
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();

        int minus1 = Random.Range(0, 2);
        int minus2 = Random.Range(0, 2);

        if (minus1 == 1)
        {
            minusA.gameObject.SetActive(true);
        }
        else
        {
            minusA.gameObject.SetActive(false);

        }
        if (minus2 == 1)
        {
            minusB.gameObject.SetActive(true);
        }
        else
        {
            minusB.gameObject.SetActive(false);

        }

        a = alphabet[Random.Range(0, alphabet.Length)];
        b = alphabet[Random.Range(0, alphabet.Length)];
        if (a == b)
        {
            b = alphabet[Random.Range(0, alphabet.Length)];
        }
        oper = operators2[Random.Range(0, operators.Length)];
        charA.text = a + "";
        charB.text = b + "";
        operatorText.text = oper + "";
        valueA = Random.Range(0, 2);
        if (valueA == 2)
        {
            textValueA.gameObject.SetActive(false);
        }
        else
        {
            textValueA.gameObject.SetActive(true);
        }
        valueB = Random.Range(0, 2);
        textValueA.text = valueA + "";
        textValueB.text = valueB + "";
        if (minus1 == 1 && valueA == 1)
        {
            valueA = 0;
        }
        else
        if (minus1 == 1 && valueA == 0)
        {
            valueA = 1;
        }

        if (minus2 == 1 && valueB == 1)
        {
            Debug.Log("CHANGED");
            valueB = 0;
        }
        else
        if (minus2 == 1 && valueB == 0)
        {
            Debug.Log("CHANGED 2");
            valueB = 1;
        }

        Text t1 = button1.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t2 = button2.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t3 = button3.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t4 = button4.transform.GetChild(0).gameObject.GetComponent<Text>();
        t1.text = "0";
        t2.text = "1";
        t3.text = a + "";
        t4.text = b + "";

        if (oper.ToString() == "→")
            operationState = OperationState.implication;
        else operationState = OperationState.StrongDisunction;

        CheckOperator();

    }

    #endregion 

    void GenerateExampleС()
    {
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();

        int type = Random.Range(1, 4);

        a = alphabet[Random.Range(0, alphabet.Length)];
        b = alphabet[Random.Range(0, alphabet.Length)];
        if (a == b)
        {
            b = alphabet[Random.Range(0, alphabet.Length)];
        }
        if (type == 1)
        {
            oper = '^';
            charA.text = "("+a + "V" + b+")";
            charB.text = "("+a + "V" + b+")";
            operatorText.text = oper + "";
            minusA.gameObject.SetActive(false);
            minusB.gameObject.SetActive(true);
        }
        if (type == 2)
        {
            oper = '^';
            charA.text =""+ a ;
            charB.text = a + "V" + b;
            operatorText.text = oper + "";
            minusA.gameObject.SetActive(false);
            minusB.gameObject.SetActive(false);
        }
        if (type == 3)
        {
            oper = '^';
            charA.text = "("+ a + "→"+ b +")";
            charB.text = "(" + a + "V" + b + ")";
            operatorText.text = oper + "";
            minusA.gameObject.SetActive(false);
            minusB.gameObject.SetActive(true);
        }


        valueA = Random.Range(0, 2);
        if (valueA == 2)
        {
            textValueA.gameObject.SetActive(false);
        }
        else
        {
            textValueA.gameObject.SetActive(true);
        }
        valueB = Random.Range(0, 2);
        textValueA.text = a+"= "+valueA ;
        textValueB.text = b+"= "+valueB ;

        Text t1 = button1.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t2 = button2.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t3 = button3.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text t4 = button4.transform.GetChild(0).gameObject.GetComponent<Text>();
        t1.text = "0";
        t2.text = "1";
        t3.text = a + "";
        t4.text = b + "";

        
        switch (type)
        {
            case 1:
                operationState = OperationState.type1;
                break;
            case 2:
                operationState = OperationState.type2;
                break;
            case 3:
                operationState = OperationState.type3;
                break;
        }
        CheckOperator();

    }

    void CheckOperator()
    {
        switch (operationState)
        {
            case OperationState.or:                                 // V          dodavanya
                if (valueA == 2 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);     // 0
                    button2.onClick.AddListener(CorrectAnswer);  // 1
                    button3.onClick.AddListener(WrongAnswer);   // a
                    button4.onClick.AddListener(WrongAnswer);   // b
                }
                else if (valueA == 2 && valueB == 0)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(CorrectAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 0)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }


                break;

            case OperationState.and:                                // ^         mnozh
                if (valueA == 2 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(CorrectAnswer);
                    button4.onClick.AddListener(WrongAnswer);


                }
                else if (valueA == 2 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 1)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                break;

            case OperationState.implication:                                 // ->        
                if (valueA == 2 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);     // 0
                    button2.onClick.AddListener(CorrectAnswer);  // 1
                    button3.onClick.AddListener(WrongAnswer);   // a
                    button4.onClick.AddListener(WrongAnswer);   // b


                }
                else if (valueA == 2 && valueB == 0)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(CorrectAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);  // 0
                    button2.onClick.AddListener(CorrectAnswer); // 1
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 0)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }


                break;

            case OperationState.StrongDisunction:                                // ^         mnozh
                if (valueA == 2 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(CorrectAnswer);
                    button4.onClick.AddListener(WrongAnswer);


                }
                else if (valueA == 2 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 1)
                {
                    button1.onClick.AddListener(CorrectAnswer);  // 0
                    button2.onClick.AddListener(WrongAnswer);  // 1
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 0)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                break;

            case OperationState.type1:
                if (valueA == 1 && valueB == 1)
                {
                    button1.onClick.AddListener(CorrectAnswer);  // 0
                    button2.onClick.AddListener(WrongAnswer);  // 1
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 0)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                break;

            case OperationState.type2:
                if (valueA == 1 )
                {
                    button1.onClick.AddListener(WrongAnswer);  // 0
                    button2.onClick.AddListener(CorrectAnswer);  // 1
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer);
                    button2.onClick.AddListener(WrongAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                break;
            case OperationState.type3:
                if (valueA == 1 && valueB == 1)
                {
                    button1.onClick.AddListener(CorrectAnswer);  // 0
                    button2.onClick.AddListener(WrongAnswer);  // 1
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 1 && valueB == 0)
                {
                    button1.onClick.AddListener(CorrectAnswer); // 0
                    button2.onClick.AddListener(WrongAnswer); // 1 
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 1)
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }
                else if (valueA == 0 && valueB == 0) 
                {
                    button1.onClick.AddListener(WrongAnswer);
                    button2.onClick.AddListener(CorrectAnswer);
                    button3.onClick.AddListener(WrongAnswer);
                    button4.onClick.AddListener(WrongAnswer);
                }

                break;
        }

    }

    void CorrectAnswer()
    {
        // Debug.Log(" Value a " + valueA + " Value b " + valueB);
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            currentButtonImage = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>();
            oldSprite = currentButtonImage.sprite;
            nextButtonImage = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>();
        }
        timer.value += 10f;
        score++;
        if (score >= levelCounter)
        {

            level++;
            levelCounter += 5;
            ShowLevel();
            if (level <= 3)
                trueLevel = level;
            else
            {
                trueLevel = level % 3;
                if (trueLevel == 0) trueLevel = 3;
            }
        }
   

        if (trueLevel == 1)
            GenerateExampleB();
        if (trueLevel == 2)
            GenerateExampleA();
        if (trueLevel == 3)
            GenerateExampleС();

        plusOneObj.SetActive(true);
        Invoke("DeactivatePlusOne",1f);
        nextButtonImage.sprite = good;
        Invoke("GiveButtonBack", 0.25f);

        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
    }

    void GiveButtonBack()
    {
        nextButtonImage.sprite = oldSprite;
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true;

    }

    void DeactivatePlusOne()
    {
        plusOneObj.SetActive(false); 
    }


    void WrongAnswer()
    {
        //  Debug.Log(" Value a " + valueA + " Value b " + valueB);
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            currentButtonImage = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>();
            oldSprite = currentButtonImage.sprite;
            nextButtonImage = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>();
        }

        timer.value -= 5f;
        if (trueLevel == 1)
            GenerateExampleB();
        if (trueLevel == 2)
            GenerateExampleA();
        if (trueLevel == 3)
            GenerateExampleA();
        nextButtonImage.sprite = bad;
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
        Invoke("GiveButtonBack", 0.25f);

    }

  
    void Update()
    {
        if (!isTutorial)
        {
          //  anim.clip = popUpAnimation;
            timer.value -= Time.deltaTime;
            if (Application.systemLanguage == SystemLanguage.Ukrainian) { timerText.text = "Час: " + Mathf.Floor(timer.value) + " сек.";  } else
            timerText.text ="Time: " +Mathf.Floor(timer.value) + " sec.";
            if (timer.value == 0)
            {

               
                anim.Play("Tutor");
                PlayerPrefs.SetInt("Scoree", score);
                PlayerPrefs.Save();
                Invoke("ShowLosePopUp", 1f);
                isTutorial = true;
                losePopUp.SetActive(true);


            }
            if (Application.systemLanguage == SystemLanguage.Ukrainian) { Score.text = "Рахунок: " + score; } else      
            Score.text = "Points: " + score;

        }
    }

    void ShowLosePopUp()
    {
        if (Application.systemLanguage == SystemLanguage.Ukrainian) { Score.text = "Рахунок: " + score; }
        else
            Score.text = "Points: " + score;
        gameObject.SetActive(false);
      

    }

    void ShowLevel()
    {
        Animation anim = Level.gameObject.GetComponent<Animation>();
        anim.Play();
        if (Application.systemLanguage == SystemLanguage.Ukrainian)
        {
            Level.text = "Рівень " + level;
        }
        else
        Level.text = "Level " + level;
    } 

    private void OnDisable()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        anim.clip = startAnimation;
        levelCounter = 5;
        level = 1;
        Level.text = "Level " + level;
        trueLevel = level;
        score = 0;
        timer.value = 30f;
        isTutorial = false;
    }


}
