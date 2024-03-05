using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;

    
    public int health { get; set; }
    
    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public override void Update()
    {
        
    }
    public void Damage()
    {
        health -= 1;
        if (health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }
    public override void Movement()
    {
        //sit still
    }

    
    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
