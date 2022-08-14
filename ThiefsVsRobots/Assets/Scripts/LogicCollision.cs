using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicCollision : MonoBehaviour
{
    [SerializeField] private GameObject _alarm;

    private bool _alarmWork = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Subject subject))
        {
            if (_alarmWork == false)
            {
                _alarmWork = true;
                _alarm.SetActive(true);
            }
        }
    }
}
