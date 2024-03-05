using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MossGiant : Enemy, IDamageable
{

    public int health { get; set; }
    
    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        health -= 1;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);
        if (health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }


}
