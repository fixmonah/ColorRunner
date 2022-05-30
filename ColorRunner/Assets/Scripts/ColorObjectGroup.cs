using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObjectGroup : MonoBehaviour
{
    [SerializeField] ColorObject[] colorObjects = null;

    public void Init(Color color, Action<Color> action)
    {
        foreach (var item in colorObjects)
        {
            item.Init(color, action);
        }
    }

    public int Length() 
    {
        return colorObjects.Length;
    }
}
