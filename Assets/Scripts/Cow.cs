using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public enum eType
    {
        Default, 
        Selected,
        Deleted
    }

    private eType type = eType.Default;
    public eType Type { get => type; set => type = value; }
    public Color colorChange = new Color(0, 0, 0, 255);

    public void Select()
    {
        colorChange = new Color(150, 150, 150, 255);
        type = eType.Selected;
    }

    public void DeSelect()
    {
        colorChange = new Color(50, 50, 50, 255);
        type = eType.Default;
    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(type == eType.Deleted)
        {
            Destroy(this);
        }
    }
}
