using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyManager
{
    protected override void Start()
    {
        base.Start();
    }
    void Update()
    {
        //utilizzo il rigidbody per il movimento dell'enemy al fine di evitare mancate collisioni
        rb.velocity = Vector3.left * movementSpeed;
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullet"))
        {
            BulletCollisionCheck();
            if (health <= 0 && chance == 0)
            {
                Instantiate(EnemyWeapon, transform.position, Quaternion.identity);
            }
        }

        if (coll.collider.CompareTag("Bomb"))
        {
            BombCollisionCheck();
        }
    }
}
