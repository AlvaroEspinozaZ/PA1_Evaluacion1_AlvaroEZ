using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [Header("PLayer Elments")]
    [SerializeField] private PlayerController player;  

    [Header("Enemys Elments")]
    [SerializeField] private List<OgreC> ogresOnMap;
    private List<OgreC> ogresRemaining;
    [SerializeField] private int countEnemysKills;
    [SerializeField] private OgreC ogre;
    
    
    [Header("Suscribers Elments")]
    [SerializeField] private UnityEvent onEndGameWin;
    [SerializeField] private UnityEvent onEndGameOver;
    private void OnGUI()
    {

        GUI.Label(new Rect(40, 80, 500, 20), string.Format("Coins Collected: {0}", ogre.points * countEnemysKills));
        GUI.Label(new Rect(40, 40, 500, 20), string.Format("Total Score: {0}", countEnemysKills));
        GUI.Label(new Rect(80, 10, 500, 20), string.Format("Vidas: {0}", player.barraVida.maxValue));


    }
   
    // Update is called once per frame
    void Start()
    {
        LogicEnemy();
    }
    private void LogicEnemy()
    {
        ogresRemaining = new List<OgreC>(ogresOnMap);
        foreach (OgreC ogre in ogresRemaining)
        {
            ogre.OnHitEnemy += HitsCollectedEnemy;
            ogre.OnHitKill += CollectedKillsEnemys;
        }
    }
    private void HitsCollectedEnemy(OgreC ogre)
    {   
        ogre.barraVida.UpdateHealth(-20);
      
    }

    private void CollectedKillsEnemys(OgreC ogre)
    {

        if (ogre.barraVida.maxValue <= 0)
        {
            countEnemysKills++;
            ogresRemaining.Remove(ogre);
        }
    }
}
