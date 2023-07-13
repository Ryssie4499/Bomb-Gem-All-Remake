using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyManager
{
    Vector3 startPos;
    Rigidbody rb;
    private int offset = 2;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
    void Update()
    {
        Bullet(offset);
        //muovo gli enemy lungo una sinusoide per rendere il movimento più fluido e controllato
        time += Time.deltaTime * movementSpeed;
        float x = time;
        float y = Mathf.Sin(time) * movementSpeed;
        transform.position = startPos + new Vector3(-x, y);
        
        //nel caso in cui gli enemy sforino dai bordi, verrebbero spinti verso il centro
        if (transform.position.y <= -7)
        {
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
        }
        else if (transform.position.y >= 7)
        {
            rb.AddForce(Vector3.down * 3f, ForceMode.Impulse);
        }
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
