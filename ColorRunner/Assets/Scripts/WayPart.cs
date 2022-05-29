using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPart : MonoBehaviour
{
    [SerializeField] private Transform _spawnNewWayPartPoint;
    [SerializeField] private TriggerEvent _playerStartTrigger;

    public Vector3 GetSpawnNewWayPartPoint() { return _spawnNewWayPartPoint.position; }

    public void ConnectToEventPlayerOnWay(Action action) 
    {
        _playerStartTrigger.SetAction(action); 
    }
}
