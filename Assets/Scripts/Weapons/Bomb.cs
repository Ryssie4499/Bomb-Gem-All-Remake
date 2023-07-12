using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //velocità delle bombe
    public int speed;

    //references
    PlayerMovement pM;
    GameManager GM;
    Rigidbody rb;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        pM = FindObjectOfType<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    //solo se il gioco è in play, la bomba si potrà muovere verso destra
    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            #region NEW VERSION
            //muovo la bomba con il rigidbody in modo che non skippi nessuna collisione
            rb.velocity = Vector3.right * speed;
            #endregion
            #region OLD VERSION
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            #endregion
        }
    }

    //se la bomba colpisce un qualsiasi oggetto in scena, si autodistrugge
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
