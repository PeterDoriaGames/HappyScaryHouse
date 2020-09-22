﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletMono : DamagerMono
{
    [SerializeField]
    private float BulletSpeed = default;
    private Vector2 ShotDir;
    private Rigidbody2D RB2D;

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RB2D.velocity = ShotDir * BulletSpeed * Time.deltaTime;
    }

    public void ChangeShotDir(Vector2 shotDir)
    {
        ShotDir = shotDir;
    }
    public override void Attack()
    {
        // instantiate boom effect here.
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DamageableMono dam = collision.gameObject.GetComponent<DamageableMono>();
        if (dam)
        {
            if (dam.damSO.faction != DamagerSO.faction)
            {
                dam.damSO.AddAmountToHealth(DamagerSO.damage);
            }
        }
    }
}
