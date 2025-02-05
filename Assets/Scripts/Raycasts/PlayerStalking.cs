using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStalking : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private RaycastPlayer _target;
    private Vector3 _rotate;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed);
        FlipX();
    }

    private void FlipX()
    {
        if (transform.position.x < 0)
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 0;
            transform.rotation = Quaternion.Euler(_rotate);
        }
        else if (transform.position.x > 0)
        {
            _rotate = transform.eulerAngles;
            _rotate.y = 180;
            transform.rotation = Quaternion.Euler(_rotate);
        }
    }

    public void TakeTarget(RaycastPlayer target)
    {
        _target = target;
    }
}