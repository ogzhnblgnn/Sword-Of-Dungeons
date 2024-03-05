using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _swordAnimator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _swordAnimator.SetTrigger("SwordAnimation");
    }
}
