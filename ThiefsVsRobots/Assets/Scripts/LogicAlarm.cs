using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class LogicAlarm : MonoBehaviour
{
    [SerializeField] private Transform _alarm;
    [SerializeField] private Transform _player;
    [SerializeField] private float _stepDistance;

    private float _volumeAlarmMax = 1;
    private float _distancePlayerAndAlarm;
    private float _volume;
    private AudioSource _soundAlarms;

    private void Start()
    {        
        _soundAlarms = GetComponent<AudioSource>();
        _soundAlarms.Play();        
    }

    private void Update()
    {    
        SetVolumeAlarm();
    }

    private void SetVolumeAlarm()
    {
        _soundAlarms.volume = _volumeAlarmMax - CalculateDistance();
    }

    private float CalculateDistance()
    {
        _distancePlayerAndAlarm = Vector3.Distance(_alarm.position, _player.position);
        _volume = Mathf.Clamp01(_distancePlayerAndAlarm * _stepDistance);
        return _volume;
    }
}
