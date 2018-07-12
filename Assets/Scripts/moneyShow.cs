using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyShow : MonoBehaviour
{
    public Text moneyText1;
    public GameObject upgradesPanel;
    private double money = 0;

    public Text helperQuote;
    private bool helperEnabled = false;
    public GameObject helperPanel;

    public Text timeRemainingDelta;
    public Text timeSpentDelta;
    public Text timeReamaining;
    public Text timeSpent;

    public GameObject browserButton;
    public GameObject superGameButton;
    public GameObject commandPromptButton;

    public Text loadingBlue;
    public Text loadingBlack;
    public float loadingDotChangeTime = 0.5f;
    private bool imersiveLoadingEnable = false;
    private String loadingDots;
    

    public List<Image> loadingbarSlices;

    public int browserValue;
    public int timeSpentValue;
    public int timeRemainingValue;
    public int gameValue;
    public int commandPromptValue;
    public int loaderValue;
    public int helpValue;
    public int myOSMusicValue;
    public int myOS10UpgradeValue;
    public int donateValue;


    private float timer;
    private float hours;
    private float minutes;
    private float seconds;

    private float loadingTime;

    public float loadSliceInitialTime;
    private float currentLoadSliceTime;
    private int barCounter=0;

    public GameObject endPanel;

    private List<String> helperQuotes;
    // Use this for initialization
    void Start()
    {
        moneyText1.text = 0.ToString()+"$";
        for (int i = 0; i < loadingbarSlices.Count; i++)
        {
            loadingbarSlices[i].enabled = false;
        }

        currentLoadSliceTime = loadSliceInitialTime;
        
        //Initialization of helperQuotes list that is being used to display messages to helper panel
        helperQuotes = new List<string>();
        helperQuotes.Add("I need to pee");
        helperQuotes.Add("Comming back ASAP");
        helperQuotes.Add("Try restarting your computer to see if it's working");
        helperQuotes.Add("Is your computer powered on?");
        helperQuotes.Add("You are 10th in the line. We are still processing your request please wait");


    }

    void Update()
    {
        timer+= Time.deltaTime;
        seconds = (timer % 60);
        minutes = Mathf.Floor(timer / 60);
        if (minutes == 60) {
            hours++;
            minutes = 0;
            changeHelperQuote();
        }
        timeSpentDelta.text = "Hours: "+hours.ToString()+" Minutes: "+minutes.ToString()+" Seconds: "+seconds.ToString("0");

        if (barCounter <= loadingbarSlices.Count - 1)
        {
            currentLoadSliceTime -= Time.deltaTime;
            Debug.Log(currentLoadSliceTime.ToString());
            if (currentLoadSliceTime <= 0)
            {
                currentLoadSliceTime += loadSliceInitialTime;
                loadingbarSlices[barCounter].enabled = true;
                barCounter++;
            }
        }
        else {
            finishLoading();
        }

        if (imersiveLoadingEnable) {
            loadingTime += Time.deltaTime;
            if (loadingTime <= 1* loadingDotChangeTime)
            {
                loadingDots = ".";
            }
            else if (loadingTime <= 2* loadingDotChangeTime) {
                loadingDots = "..";
            } else if(loadingTime<=3 * loadingDotChangeTime)
            {
                loadingDots = "...";
            }
            else{
                loadingTime = 0;
            }
            loadingBlack.text = "Loading" + loadingDots;
            loadingBlue.text = "Loading" + loadingDots;
        }

    }

    private void finishLoading() {
        Debug.Log("Finished Loading");
        endPanel.SetActive(true);
    }

    public void increaseMoney()
    {

        money += UnityEngine.Random.Range((float)5, 10);

        moneyText1.text = money.ToString("0.00")+"$";


    }

    public void showUpgradesPanel() {
        upgradesPanel.SetActive(true);
    }

    public void closeUpgradesPanel() {
        upgradesPanel.SetActive(false);
    }

    public void browserUpgrade() {
        if (money >= browserValue) {
            money -= browserValue;
            moneyText1.text = money.ToString();
            GameObject.Find("Upgrade1").SetActive(false);
            browserButton.SetActive(true);
        }
    }
    public void timeRemainingUpgrade()
    {
        if (money >= timeRemainingValue)
        {
            money -= timeRemainingValue;
            moneyText1.text = money.ToString("0.00");
            GameObject.Find("Upgrade2").SetActive(false);
            timeReamaining.enabled=true;
            timeRemainingDelta.enabled = true;
        }
    }
    public void timeSpentUpgrade()
    {
        if (money >= timeSpentValue)
        {
            money -= timeSpentValue;
            moneyText1.text = money.ToString("0.00")+"$";
            GameObject.Find("Upgrade3").SetActive(false);
            timeSpent.enabled = true;
            timeSpentDelta.enabled = true;
        }
    }
    public void gameUpgrade()
    {
        if (money >= gameValue)
        {
            money -= gameValue;
            moneyText1.text = money.ToString("0.00") + "$";
            GameObject.Find("Upgrade4").SetActive(false);
            superGameButton.SetActive(true);
        }
    }
    public void commandPromptUpgrade()
    {
        if (money >= commandPromptValue)
        {
            money -= commandPromptValue;
            moneyText1.text = money.ToString("0.00") + "$";
            GameObject.Find("Upgrade5").SetActive(false);
            commandPromptButton.SetActive(true);
        }
    }
    public void loaderUpgrade()
    {
        if (money >= loaderValue)
        {
            money -= loaderValue;
            moneyText1.text = money.ToString("0.00") + "$";
            GameObject.Find("Upgrade6").SetActive(false);
            loadingBlue.enabled = true;
            loadingBlack.enabled = true;
            imersiveLoadingEnable = true;
        }
    }
    public void helpUpgrade()
    {
        if (money >= helpValue)
        {
            money -= helpValue;
            moneyText1.text = money.ToString("0.00") + "$";
            GameObject.Find("Upgrade7").SetActive(false);
            helperEnabled = true;
            helperPanel.SetActive(true);
            changeHelperQuote();
        }
    }

    public void myOSMusicUpgrade()
    {
        if (money >= myOSMusicValue)
        {
            money -= myOSMusicValue;
            moneyText1.text = money.ToString("0.00") + "$";
            GameObject.Find("Upgrade8").SetActive(false);
            GameObject.Find("AudioManager").GetComponent<AudioSource>().enabled = true;
        }
    }

    public void myOS10Upgrade()
    {
        if (money >= myOS10UpgradeValue)
        {
            money -= myOS10UpgradeValue;
            moneyText1.text = money.ToString("0.00") + "$";
            GameObject.Find("Upgrade9").SetActive(false);
            timeDecrease();
        }
    }

    public void donateUpgrade()
    {
        if (money >= donateValue)
        {
            money -= donateValue;
            moneyText1.text = money.ToString("0.00") + "$";

        }
    }


    public void timeDecrease()
    {
        loadSliceInitialTime = loadSliceInitialTime * 0.5F;
        currentLoadSliceTime = currentLoadSliceTime * 0.5F;

    }

    public void changeHelperQuote() {
        if (helperEnabled) {
            helperQuote.text = helperQuotes[UnityEngine.Random.Range(0, helperQuotes.Count - 1)];
        }
    }

    public void endGame()
    {
        Application.Quit();
    }
}
