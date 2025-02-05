using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _pointOne;
    [SerializeField] private Transform _pointTwo;
    [SerializeField] private float _speed;
    
    private bool _moveBackward;
    private Vector3 _rotate;

    private void Start()
    {
        transform.position = _pointOne.position;
    }

    private void Update()
    {
        Move(_moveBackward ? _pointTwo : _pointOne);
    }

    private void Move(Transform target)
    {
        transform.position = 
            Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _moveBackward = !_moveBackward;
            FlipX();
        }
    }

    private void FlipX()
    {
        if (_moveBackward)
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 0;
            transform.rotation = Quaternion.Euler(_rotate);
        }
        else
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 180;
            transform.rotation = Quaternion.Euler(_rotate);
        }
    }
}