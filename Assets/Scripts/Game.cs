using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    static List<Cow> cows = new List<Cow>();

    public TMP_Text playerNameText;
    public StringData p1Name;
    public StringData p2Name;

    private bool isP1Turn;

    public void Start()
    {
        
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

        isP1Turn = !(isP1Turn);
        if (isP1Turn) playerNameText.text = p1Name;
        if (!isP1Turn) playerNameText.text = p2Name;
    }

    public void AddCow(Cow c)
    {
        cows.Add(c);
    }
}
