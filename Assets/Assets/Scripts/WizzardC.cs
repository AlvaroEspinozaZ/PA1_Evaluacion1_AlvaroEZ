using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WizzardC : MonoBehaviour
{
    [SerializeField] public float points = 20;
    [SerializeField] public Enemy vistaWizzard;
    [SerializeField] public Transform playerObj;
    [SerializeField] public float intervalo = 1 ;
    [Header("Proyectil")]
    [SerializeField] private GameObject bala;
    [Header("Vida")]
    [SerializeField] public HealthBarController barraVida;
    public event Action<WizzardC> OnHitEnemy;
    public event Action<WizzardC> OnHitKill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vistaWizzard.perseguir == true)
        {
            
        }
        else
        {
        }
        
    }  
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
