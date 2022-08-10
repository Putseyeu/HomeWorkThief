using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGround : MonoBehaviour
{
    [HideInInspector] public AudioSource Alarm;
    [SerializeField] private AudioClip _clipAlarm;
    [SerializeField] private Transform _alarm;
    [SerializeField] private Transform _player;
    [SerializeField] private float _stepDistance;

    private float _volumeAlarmMax = 1;
    private bool _alarmWork = false;
    private float _distancePlayerAndAlarm;
    private float _volume;

    private void Start()
    {
        Alarm = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SetVolumeAlarm();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Subject subject))
        {
            if (_alarmWork == false)
            {
                _alarmWork = true;
                Alarm.Play();
            }
        }
    }

    private void SetVolumeAlarm()
    {      
        Alarm.volume = _volumeAlarmMax - CalculateDistance();
    }
    
    private float CalculateDistance()
    {
        _distancePlayerAndAlarm = Vector3.Distance(_alarm.position, _player.position);
        _volume = Mathf.Clamp01(_distancePlayerAndAlarm * _stepDistance);
        return _volume;
    }
}


