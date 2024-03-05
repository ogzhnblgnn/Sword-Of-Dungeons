﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (_canDamage)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(AttackCoolDown());
            }
        }
    }
    

    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    } 
}
