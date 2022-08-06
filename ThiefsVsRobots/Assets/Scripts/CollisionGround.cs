using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGround : MonoBehaviour
{
    [SerializeField] private AudioClip _clipAlarm;
    [SerializeField] private Transform _alarm;
    [SerializeField] private Transform _player;
    [SerializeField] float stepDistance = 0.02f;

    private float _volumeAlarmMax = 1;
    private bool _alarmWork = false;
    private float _volumeAlarm;

    private void Update()
    {
        _volumeAlarm = Vector3.Distance(_alarm.position, _player.position);
        Debug.Log(_volumeAlarm);
        GetComponent<AudioSource>().volume = _volumeAlarmMax - ÑalculationDistance(_volumeAlarm);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Subject")
        {
            if (_alarmWork == false)
            {
                _alarmWork = true;
                GetComponent<AudioSource>().Play();                
            }
        }       
    }
    
    private float ÑalculationDistance(float volume)
    {
        volume = Mathf.Clamp01(volume * stepDistance);
        return volume;
    }
}


