using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPart : MonoBehaviour
{
    [SerializeField] private Transform _spawnNewWayPartPoint;
    [SerializeField] private TriggerEvent _playerStartTrigger;
    [Header("Interactive objects")]
    [SerializeField] private ColorObject _selectedColorZone;
    [SerializeField] private ColorObjectGroup[] _colorGroups;


    private Color[] _otherColors;
    private Color _selectedColor;

    public Vector3 GetSpawnNewWayPartPoint() { return _spawnNewWayPartPoint.position; }

    public void ConnectToEventPlayerOnWay(Action action) 
    {
        _playerStartTrigger.SetAction(action); 
    }
    public void ConnectToSelectColorObject(Color color, Action<Color> action) 
    {
        _selectedColor = color;
        _selectedColorZone.Init(color, action);
    }
    public void ConnectToObjectColorGroups(Color[] colors, Action<Color> action)
    {
        _otherColors = colors;

        System.Random random = new System.Random();
        int selectedColorGroup = random.Next(0, _colorGroups.Length);
        _colorGroups[selectedColorGroup].Init(_selectedColor, action);

        List<Color> otherColors = new List<Color>();
        otherColors.AddRange(colors);
        otherColors.Remove(_selectedColor);
        
        for (int i = otherColors.Count - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            Color temp = otherColors[j];
            otherColors[j] = otherColors[i];
            otherColors[i] = temp;
        }
        
        for (int k = 0; k < _colorGroups.Length; k++)
        {
            if (_colorGroups[k].Length() > 0 && k != selectedColorGroup)
            {
                _colorGroups[k].Init(otherColors[k], action); 
            }
        }
    }
}
