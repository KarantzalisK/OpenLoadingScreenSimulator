using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class commandPrompt : MonoBehaviour {

    public Text prompt;
    public InputField inputField;
    public Text result;
    private List<string> listAnswers;
    private List<string> listQuestions;
    private int pointer;

    // Use this for initialization
    void Start () {
        listAnswers=new List<string>();
        listQuestions = new List<string>();

        //Q1
        listQuestions.Add("1+1?");
        listAnswers.Add("2");

        //Q2
        listQuestions.Add("Is this a bad game?");
        listAnswers.Add("yes");

        //Q3
        listQuestions.Add("Are you sure?");
        listAnswers.Add("yes");

        //Q4
        listQuestions.Add("You wanna recommend it?");
        listAnswers.Add("maybe");

        //Q5
        listQuestions.Add("How many fingers does an onion have?");
        listAnswers.Add("0");

        pointer = 0;

        prompt.text = listQuestions[pointer];
    }


    // Update is called once per frame
    void Update () {

        if (inputField.text != "" && Input.GetKey(KeyCode.Return))
        {
            EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
            inputField.OnPointerClick(new PointerEventData(EventSystem.current));

            //Correct Answer
            if (inputField.text.ToLower().Equals(listAnswers[pointer]))
            {
                pointer++;
                //we have questions left
                if (!(pointer == listQuestions.Count))
                {
                    result.text = "<color=lime>Correct!</color>";
                    prompt.text = listQuestions[pointer];
                    inputField.text = "";
                }
                //we answered all the questions
                else {
                    finish();
                }
            }
            //Wrong Answer
            else {
                pointer = 0;
                prompt.text= listQuestions[pointer];
                result.text = "<color=#F52429>Wrong!</color>";
                inputField.text = "";

            }
        }

    }

    private void finish() {
        inputField.text = "";
        result.text = "<color=lime>Hacked Succefully!</color>";
        inputField.enabled = false;
        GameObject.Find("GameManager").GetComponent<moneyShow>().timeDecrease();
    }
}
