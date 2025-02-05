using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class RaycastPlayer : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private float _directionX;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _directionX = Input.GetAxis(Horizontal) * _speed;
        
        _rigidbody2D.velocity = new Vector2(_directionX, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == false)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpSpeed);
            _isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out RaycastGround ground))
            _isGrounded = false;
    }
}
