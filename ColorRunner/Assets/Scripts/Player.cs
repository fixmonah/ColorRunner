using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _parentObject;
    private int _level;
    Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public int GetLevel() 
    {
        return _level; 
    }

    public void AddLevel()
    {
        if (_level < 10)
        {
            _level++;
        }
        ChangeSize();
    }
    public void RemoveLevel()
    {
        if (_level > -1)
        {
            _level--;
        }
        ChangeSize();
    }
    public void ResetLevel() 
    {
        _level = 0;
    }
    private void ChangeSize()
    {
        _parentObject.localScale = Vector3.one * (1 + _level * 0.05f);
    }
    public void SetColor(Color color)
    {
        if (_renderer != null)
        {
            _renderer = GetComponent<Renderer>();
            _renderer.material.color = color;
        }
        else // just in case
        {
            Debug.LogError("NoMaterial");
        }
    }
}
