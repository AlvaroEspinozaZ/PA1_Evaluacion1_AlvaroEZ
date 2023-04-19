using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WizzardC : MonoBehaviour
{
    [SerializeField] public float points = 20;
    [SerializeField] public Enemy vistaWizzard;
    [SerializeField] public Transform playerObj;

    [Header("Vida")]
    [SerializeField] public HealthBarController barraVida;
    public event Action<WizzardC> OnHitEnemy;
    public event Action<WizzardC> OnHitKill;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            barraVida.maxValue = barraVida.maxValue - 10;
            Debug.Log(barraVida.maxValue);
            OnHitEnemy?.Invoke(this);
            if (barraVida.maxValue <= 0)
            {
                OnHitKill?.Invoke(this);
                gameObject.SetActive(false);
            }
        }
    }
}
