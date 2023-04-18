using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    public event Action<Enemy> HitToPlayer;
    public bool perseguir = false;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            perseguir = true;
            HitToPlayer?.Invoke(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            perseguir = false;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        HitToPlayer?.Invoke(this);
    }
}
