using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayGenerator : MonoBehaviour
{
    [SerializeField] private WayPart _wayPartPrefab;

    private WayPart[] _wayParts = new WayPart[3];
    private WayPart _lastWayPart;

    private void Start()
    {
        _lastWayPart = InstantiateWayPart(this.transform.position);
        _wayParts[1] = _lastWayPart;
        _lastWayPart = InstantiateWayPart(_lastWayPart.GetSpawnNewWayPartPoint());
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
        _lastWayPart = InstantiateWayPart(_lastWayPart.GetSpawnNewWayPartPoint());
        _wayParts[2] = _lastWayPart;
        _wayParts[1].ConnectToEventPlayerOnWay(AddNewWayPart);
    }
}
