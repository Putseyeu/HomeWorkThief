using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _pathTime;
   
    private float _volumeAlarmMin = 0;
    private AudioSource _soundAlarms;
    private Coroutine _makeLouder;
    private Coroutine _makeQuieter;
    private bool _makeLouderIsWork = false;
    private bool _makeQuieterIsWork = false;
    private float _tempVolume;

    private void Start()
    {
        _soundAlarms = GetComponent<AudioSource>();
        _soundAlarms.volume = _volumeAlarmMin;
    }

    public void TurnSound()
    {
        _soundAlarms.Play();
    }

    public void StartMakeLouder()
    {
        if (_makeQuieterIsWork == true)
        {
            StopCoroutine(_makeQuieter);
        }
        
        _makeLouderIsWork = true;
        _makeLouder = StartCoroutine(MakeLouder());        
    }

    public void StarMakeQuieter()
    {
        if (_makeLouderIsWork == true)
        {
            StopCoroutine(_makeLouder);
        }
        
        _makeQuieterIsWork = true;
        _makeQuieter = StartCoroutine(MakeQuieter());
    }

    private IEnumerator MakeQuieter()
    {
        float runningTime = 0;

        while (runningTime < _pathTime)
        {
            runningTime += Time.deltaTime;
            _soundAlarms.volume = _tempVolume - runningTime / _pathTime;
            yield return null;
        }       
    }

    private IEnumerator MakeLouder()
    {
        float runningTime = 0;

        while (runningTime < _pathTime)
        {
            runningTime += Time.deltaTime;
            _soundAlarms.volume = runningTime/ _pathTime;
            _tempVolume = _soundAlarms.volume;
            yield return null;
        }
    }
}
