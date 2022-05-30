using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayGenerator : MonoBehaviour
{
    [SerializeField] private WayPart _wayPartPrefab;
    [SerializeField] private Color[] _colors;

    private Color _selectedColor = Color.black;

    private WayPart[] _wayParts = new WayPart[3];
    private WayPart _lastWayPart;


    private void Start()
    {
        _selectedColor = GetRandomColor();
        _lastWayPart = InstantiateWayPart(this.transform.position);
        _lastWayPart.ConnectToSelectColorObject(_selectedColor, SetSelectedColor);
        _lastWayPart.ConnectToObjectColorGroups(_colors, TouchColorObject);
        _wayParts[1] = _lastWayPart;

        _selectedColor = GetRandomColor();
        _lastWayPart = InstantiateWayPart(_lastWayPart.GetSpawnNewWayPartPoint());
        _lastWayPart.ConnectToSelectColorObject(_selectedColor, SetSelectedColor);
        _lastWayPart.ConnectToObjectColorGroups(_colors, TouchColorObject);
        _wayParts[2] = _lastWayPart;

        _wayParts[1].ConnectToEventPlayerOnWay(AddNewWayPart);
    }
    private WayPart InstantiateWayPart(Vector3 position) 
    {
        WayPart wayPart = Instantiate(_wayPartPrefab, position, Quaternion.identity, transform);
        return wayPart;
    }
    private void AddNewWayPart()
    {
        if (_wayParts[0] != null)
        {
            Destroy(_wayParts[0].gameObject);
        }
        _wayParts[0] = _wayParts[1];
        _wayParts[1] = _wayParts[2];

        _selectedColor = GetRandomColor();
        _lastWayPart = InstantiateWayPart(_lastWayPart.GetSpawnNewWayPartPoint());
        _lastWayPart.ConnectToSelectColorObject(_selectedColor, SetSelectedColor);
        _lastWayPart.ConnectToObjectColorGroups(_colors, TouchColorObject);
        _wayParts[2] = _lastWayPart;

        _wayParts[1].ConnectToEventPlayerOnWay(AddNewWayPart);

    }

    private Color GetRandomColor() 
    {
        List<Color> colors = new List<Color>();
        foreach (var item in _colors)
        {
            colors.Add(item);
        }
        colors.Remove(_selectedColor);

        System.Random random = new System.Random();
        return colors[random.Next(0, colors.Count)];
    }


    Color tSelectColor;

    private void SetSelectedColor(Color color)
    {
        tSelectColor = color;
        Debug.Log($"SelectColor");
    }
    private void TouchColorObject(Color color)
    {
        if (tSelectColor == color)
        {
            Debug.Log($"True");
        }
        else
        {
            Debug.Log($"False");
        }
    }
}
