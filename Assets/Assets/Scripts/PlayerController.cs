using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [Header("Proyectil")]
    [SerializeField] private GameObject bala;
    private BalaC prfBala;
    [Header("Vida")]
    [SerializeField] public HealthBarController barraVida;

    private void Start()
    {
        prfBala = GetComponent<BalaC>();
    }
    private void Update() {
        Vector2 movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 puntero = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CheckFlip(mouseInput.x);
       
        RaycastHit2D ray= Physics2D.Raycast(transform.position, mouseInput.normalized * rayDistance);
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0)){
            //Debug.Log("Right Click");
            float anguloRadianes = Mathf.Atan2(puntero.y - transform.position.y, puntero.x - transform.position.x);
            float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
            GameObject asd = Instantiate(bala, transform.position, Quaternion.Euler(0, 0, anguloGrados));
            

        }
        else if(Input.GetMouseButtonDown(1)){
            //Debug.Log("Left Click");
            float anguloRadianes = Mathf.Atan2(puntero.y - transform.position.y, puntero.x - transform.position.x);
            float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
            GameObject asd = Instantiate(bala, transform.position, Quaternion.Euler(0, 0, anguloGrados));
            GameObject asd1 = Instantiate(bala, transform.position, Quaternion.Euler(0, 0, anguloGrados+45));
            GameObject asd2 = Instantiate(bala, transform.position, Quaternion.Euler(0, 0, anguloGrados-45));
        }
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
     
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            barraVida.UpdateHealth(-20);
            barraVida.maxValue -= 20;
            Debug.Log(collision.gameObject);
            MovimientoCa.Instance.MoverCamara(5, 5, 0.5f);
        }
    }
}
