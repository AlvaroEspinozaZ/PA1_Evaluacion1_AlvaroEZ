using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("PLayer Elments")]
    [SerializeField] private PlayerController player;
    [SerializeField] private HealthBarController barraVida;
    private void OnGUI()
    {

        GUI.Label(new Rect(600, 10, 500, 20), string.Format("Coins Collected: {0}"));
        GUI.Label(new Rect(600, 30, 500, 20), string.Format("Total Score: {0}"));
        GUI.Label(new Rect(40, 10, 500, 20), string.Format("Vidas: {0}", barraVida.maxValue));


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
