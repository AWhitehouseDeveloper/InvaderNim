using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public Color colorChange = new Color(0, 0, 0, 255);

    public void Select()
    {
        colorChange = new Color(100, 100, 100, 255);
    }

    public void DeSelect()
    {
        colorChange = new Color(0, 0, 0, 255);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
