using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmControlPoint : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool _alarmWork = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Thiefs thiefs))
        {
            if (_alarmWork == false)
            {
                _alarm.TurnSound();
                _alarmWork = true;
                _alarm.StartMakeLouder();
            }
            else
            {
                _alarmWork = false;
                _alarm.StarMakeQuieter();
            }
        }
    }
}
