using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _pathTime;
   
    private float _volumeAlarmMax = 1f;
    private float _volumeAlarmMin = 0;
    private AudioSource _soundAlarms;
    private bool _alarmWork = false;

    private void Start()
    {
        _soundAlarms = GetComponent<AudioSource>();                
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Thiefs thiefs))
        {
            if (_alarmWork == false)
            {
                _soundAlarms.volume = _volumeAlarmMax;
                _soundAlarms.Play();
                _alarmWork = true;
            }
            else
            {
                StartCoroutine(MakeQuieter());
                _alarmWork = false;
            }
        }
    }

    private IEnumerator MakeQuieter()
    {
        float _pathRuningTime = 0;

        while (_soundAlarms.volume > _volumeAlarmMin)
        {
            _pathRuningTime += Time.deltaTime;
            _soundAlarms.volume = _volumeAlarmMax - _pathRuningTime / _pathTime;
            yield return null;
        }       
    }
}
