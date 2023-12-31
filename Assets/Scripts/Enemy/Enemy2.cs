using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyManager
{
    private int offset = 5;
    protected override void Start()
    {
        base.Start();
    }
    void Update()
    {
        //utilizzo il rigidbody per il movimento dell'enemy al fine di evitare mancate collisioni
        rb.velocity = Vector3.left * movementSpeed;
        Bullet(offset);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullet"))
        {
            BulletCollisionCheck();
        }

        if (coll.collider.CompareTag("Bomb"))
        {
            BombCollisionCheck();
        }
    }
}
