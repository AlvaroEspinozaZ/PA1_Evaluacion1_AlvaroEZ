using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreC : MonoBehaviour
{
    [SerializeField] public Transform Obe;
    [SerializeField]  float vel;
    Rigidbody2D rgb;
    [Header("Vida")]
    [SerializeField] private HealthBarController barraVida;
    bool perseguir=false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (perseguir==true)
        {
            rgb.velocity = ((Obe.position - transform.position) * vel);
            
        }
        else
        {
            rgb.velocity = ((Obe.position - transform.position) * 0);
        }
       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            perseguir = true;

        }
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            barraVida.UpdateHealth(-20);
            Debug.Log(collision.gameObject);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            perseguir = false;
        }
       
    }
}
