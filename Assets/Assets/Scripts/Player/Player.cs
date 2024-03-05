using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float _jumpforce = 7.0f;
    private Rigidbody2D _rigidbody2D;
    private bool _resetJump = false;
    private bool _grounded = false;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordArcSprite;
    [SerializeField] private float _speed = 4f;
    
    public int health { get; set; }
    
     void Start()
     {
         _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
         _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
         _playerAnimation = GetComponent<PlayerAnimation>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnimation.Attack();
        }
    }

    public void Damage()
    {
        
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpforce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnimation.Jump(true);
        }
        _rigidbody2D.velocity = new Vector2(move * _speed, _rigidbody2D.velocity.y);
        _playerAnimation.Move(move);

    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        if (hitInfo != null)
        {
            if (_resetJump == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    void Flip(bool facingRight)
    {
        if (facingRight)
        {
            _spriteRenderer.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else
        {
            _spriteRenderer.flipX = true;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;        
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(1.0f);
        _resetJump = false;
    }

    
}
