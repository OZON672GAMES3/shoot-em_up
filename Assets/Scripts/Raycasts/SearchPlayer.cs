using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    [SerializeField] private Transform _originalVector;
    [SerializeField] private float _maxDistance;
    [SerializeField] private PlayerStalking _playerStalking;
    [SerializeField] private EnemyMover _enemyMover;
    
    private RaycastHit2D _raycastHit2D;
    private Vector2 _vector2;
    private Vector3 _rotate;

    private void Update()
    {
        _rotate = transform.eulerAngles;

        _vector2 = _rotate.y == 0 ? Vector2.right : Vector2.left;
        
        Debug.DrawRay(_originalVector.position, _vector2 * _maxDistance, Color.blue);

        if (Physics2D.Raycast(_originalVector.position, _vector2, _maxDistance))
        {
            _raycastHit2D = Physics2D.Raycast(_originalVector.position, _vector2, _maxDistance);

            if (_raycastHit2D.collider.TryGetComponent(out RaycastPlayer raycastPlayer))
            {
                _playerStalking.enabled = true;
                _playerStalking.TakeTarget(raycastPlayer);
                _enemyMover.enabled = false;
                enabled = false;
            }
        }
    }
}