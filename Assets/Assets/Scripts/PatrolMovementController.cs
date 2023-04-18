using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovementController : MonoBehaviour
{
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocityModifier = 5f;
    private Transform currentPositionTarget;
    [Header("Raycast")]
    [SerializeField] public LayerMask Player;
    [SerializeField] private float distanceModify;
    private int patrolPos = 0;

    private void Start() {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
    }

    private void Update() {
        CheckNewPoint();
        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);
    }

    private void CheckNewPoint(){
        if(Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25){
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length? 0: patrolPos+1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier;
            CheckFlip(myRBD2.velocity.x);
            
        }
        RaycastHit2D ray = Physics2D.Raycast(transform.position, (currentPositionTarget.position - transform.position).normalized * distanceModify, Player);
        if (ray.collider.tag == "Player")
        {
            Debug.Log(ray.collider.gameObject);
            velocityModifier = 6;
            Debug.Log("cas");
            
        }
        Debug.DrawRay(transform.position, (currentPositionTarget.position - transform.position).normalized * distanceModify, Color.red);
        
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
   
}
