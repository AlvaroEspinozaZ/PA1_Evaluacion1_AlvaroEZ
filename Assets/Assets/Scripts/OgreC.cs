using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OgreC : MonoBehaviour
{
    [SerializeField] public Transform Obe;
    [SerializeField]  float vel;
    [SerializeField] public float points=10;
    [SerializeField] public Enemy vistaOgre;
    Rigidbody2D rgb;
    [Header("Vida")]
    [SerializeField] public HealthBarController barraVida;
    [SerializeField] private Vector2 Quieto;

    public event Action<OgreC> OnHitEnemy;
    public event Action<OgreC> OnHitKill;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        Quieto = (transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Atacando = (Obe.position - transform.position);
        Vector2 regresando = new Vector2(Quieto.x - transform.position.x, Quieto.y - transform.position.y);
        if (vistaOgre.perseguir == true)
        {
            
            rgb.velocity = (Atacando * vel);            
        }
        else
        {
            rgb.velocity = regresando*0.5f;
            if (transform.position.x <= Quieto.x&& transform.position.y <= Quieto.y)
            {
                rgb.velocity = regresando* 0;
            }
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            barraVida.maxValue = barraVida.maxValue- 20;
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
