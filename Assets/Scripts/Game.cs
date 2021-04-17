using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public static List<Cow> cows = new List<Cow>();

    public GameObject userPanel;
    public GameObject winnerPanel;
    public GameObject firstTurnPanel;
    public GameObject forfeitPanel;

    public TMP_Text playerNameText;
    public TMP_Text playerFirstText;
    public TMP_Text playerWinnerText;
    public StringData p1Name;
    public StringData p2Name;
    public StringData winnerName;

    private bool isP1Turn = true;
    int visiableCows;

    private static Game instance = new Game();
    public static Game Instance() 
    {
        return instance; 
    }

    private void Start()
    {
        OnFirstSelect();
    }

    public void OnToGame()
    {
        firstTurnPanel.SetActive(false);
        userPanel.SetActive(true);
        visiableCows = cows.Count;

        if (isP1Turn) playerNameText.text = p1Name;
        if (!isP1Turn) playerNameText.text = p2Name;
    }

    public void OnFinish()
    {
        foreach(Cow c in cows)
        {
            if(c.Type == Cow.eType.Selected)
            {
                c.Type = Cow.eType.Deleted;
                visiableCows--;
            }
        }
        Debug.Log(visiableCows);
        if(visiableCows == 0)
        {
            if (isP1Turn) winnerName = p2Name;
            else winnerName = p1Name;
            winnerPanel.SetActive(true);
            userPanel.SetActive(false);
            playerWinnerText.text = winnerName + " won";
        }

        isP1Turn = !(isP1Turn);
        if (isP1Turn) playerNameText.text = p1Name.value;
        if (!isP1Turn) playerNameText.text = p2Name.value;

        Debug.Log(isP1Turn);
    }

    public void OnForfeit()
    {
        forfeitPanel.SetActive(true);
        userPanel.SetActive(false);
    }

    public void OnForfeitNot()
    {
        forfeitPanel.SetActive(false);
        OnToGame();
    }

    public void OnForfeitYes()
    {
        if (isP1Turn) winnerName = p2Name;
        else winnerName = p1Name;
        forfeitPanel.SetActive(false);
        winnerPanel.SetActive(true);
        userPanel.SetActive(false);
        playerWinnerText.text = winnerName;
    }

    public void OnFirstSelect()
    {
        firstTurnPanel.SetActive(true);
        userPanel.SetActive(false);
        isP1Turn = (Random.Range(0, 2) == 1 ? true : false);
        if(isP1Turn)
        {
           playerFirstText.text = p1Name +" \nis going first";
        }
        else
        {
           playerFirstText.text = p2Name +" \nis going first";
        }
    }

    public void AddCow(Cow c)
    {
        cows.Add(c);
    }
}
