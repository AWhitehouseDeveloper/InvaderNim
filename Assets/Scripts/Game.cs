using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    static List<Cow> cows = new List<Cow>();

    public TMP_Text playerNameText;
    public TMP_Text playerWinnerText;
    public StringData p1Name;
    public StringData p2Name;
    public StringData winnerName;

    private bool isP1Turn = true;

    private static Game instance;
    public static Game Instance() 
    {
        return instance; 
    }

    public void Awake()
    {
        instance = this;
    }

    public void OnFinish()
    {
        foreach(Cow c in cows)
        {
            if(c.Type == Cow.eType.Selected)
            {
                c.Type = Cow.eType.Deleted;
            }
        }

        if(cows.Count == 0)
        {
            if (isP1Turn) winnerName = p2Name;
            else winnerName = p1Name;
            playerWinnerText.text = winnerName;
        }

        isP1Turn = !(isP1Turn);
        if (isP1Turn) playerNameText.text = p1Name;
        if (!isP1Turn) playerNameText.text = p2Name;

        Debug.Log(isP1Turn);
    }

    public void AddCow(Cow c)
    {
        cows.Add(c);
    }
}
