using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [Header("PLayer Elments")]
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private int countEnemyOgre;
    [SerializeField] private int countEnemyWizzard;

    [Header("Ogre Elments")]
    [SerializeField] private List<OgreC> ogresOnMap;
    private List<OgreC> ogresRemaining;    
    [SerializeField] private OgreC ogre;

    [Header("Wizzard Elments")]
    [SerializeField] private List<WizzardC> wizzardsOnMap;
    private List<WizzardC> wizzardsRemaining;
    [SerializeField] private WizzardC wizzard;
    [SerializeField] private GameObject balaWizzard;
    [SerializeField] private float count;

    [Header("Scorpion Elments")]
    [SerializeField] private List<OgreC> scorpionsOnMap;
    private List<OgreC> scorpionsRemaining;
    [SerializeField] private OgreC scorpion;

    [Header("Suscribers Elments")]
    [SerializeField] private UnityEvent onEndGameWin;
    [SerializeField] private UnityEvent onEndGameOver;
    private void OnGUI()
    {

        GUI.Label(new Rect(40, 80, 500, 20), string.Format("Coins Collected: {0}", ogre.points * countEnemyOgre + wizzard.points * countEnemyWizzard));
        GUI.Label(new Rect(40, 40, 500, 20), string.Format("Total Score: {0}", countEnemyOgre + countEnemyWizzard));
        GUI.Label(new Rect(80, 10, 500, 20), string.Format("Vidas: {0}", player.barraVida.maxValue));
        
    }
    // Update is called once per frame
    void Start()
    {
        LogicEnemy();
        player.OnHitEnemy += Muerte;
    }
    private void LogicEnemy()
    {
        

        ogresRemaining = new List<OgreC>(ogresOnMap);
        foreach (OgreC ogre in ogresRemaining)
        {
            ogre.OnHitEnemy += HitsCollectedOgre;
            ogre.OnHitKill += CollectedKillsOgre;
        }
        wizzardsRemaining = new List<WizzardC>(wizzardsOnMap);
        foreach (WizzardC wizzard in wizzardsRemaining)
        {           
            wizzard.vistaWizzard.HitToPlayer += HitsCollectedWizzard;        
            wizzard.OnHitEnemy += HitsCollectedWizzard;
            wizzard.OnHitKill += CollectedKillsWizzard;
        }
    }
    private void HitsCollectedOgre(OgreC ogre)
    {
        
        ogre.barraVida.UpdateHealth(-20);        
       
    }
    private void CollectedKillsOgre(OgreC ogre)
    {
        if (ogre.barraVida.maxValue <= 0)
        {
            countEnemyOgre++;
            ogresRemaining.Remove(ogre);
        }
    }
    private void HitsCollectedWizzard(Enemy wizzardDisparo)
    {
        
            float anguloRadianes = Mathf.Atan2(playerObj.position.y - wizzardDisparo.transform.position.y, playerObj.position.x - wizzardDisparo.transform.position.x);
            float anguloGrados = (180 / Mathf.PI) * anguloRadianes - 90;
            GameObject asd = Instantiate(balaWizzard, wizzardDisparo.transform.position, Quaternion.Euler(0, 0, anguloGrados));

        
    }
    private void HitsCollectedWizzard(WizzardC wizzard)
    {
        wizzard.barraVida.UpdateHealth(-10);
        
    }
    private void CollectedKillsWizzard(WizzardC wizzard)
    {
        if (wizzard.barraVida.maxValue <= 0)
        {
            countEnemyWizzard++;
            wizzardsRemaining.Remove(wizzard);
        }
        if(ogresRemaining.Count+ wizzardsRemaining.Count == 0)
        {
            onEndGameWin?.Invoke();
        }
       
    }
    private void Muerte(PlayerController play)
    {
        if (player.barraVida.maxValue <= 0)
        {
            onEndGameOver?.Invoke();
        }
    }
}
