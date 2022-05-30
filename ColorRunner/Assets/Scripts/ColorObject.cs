using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private bool destroyObjectIfPlayerNouch;

    private Action<Color> onTrigger; // not best of security. Best use is Event
    private Color _color;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Init(Color color, Action<Color> action) 
    {
        _color = color;
        SetColorInMaterial(color);
        onTrigger = action;
    }

    //public void SetColor(Color color)
    //{ 
    //    _color = color;
    //    SetColorInMaterial(color);
    //}
    //public void SetAction(Action action)
    //{
    //    onTrigger = action;
    //}

    private void SetColorInMaterial(Color color)
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer != null)
        {
            _renderer.material.color = color;
        }
        else // just in case
        {
            Debug.LogError("NoMaterial");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            onTrigger?.Invoke(_color);
            if (destroyObjectIfPlayerNouch)
            {
                Destroy(gameObject);
            }
        }
    }
}
