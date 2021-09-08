using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject backgroundObj;
    public GameObject pointSpawnEnemyObj;
    public GameObject enemyObj;

    public static int countActiveEnemies = 0;
    public static int countDeathEnemy = 0;
    public static int maxKilledEnemies = 0;

    
    void Start()
    {
        Instantiate(playerObj);
        Instantiate(backgroundObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(pointSpawnEnemyObj, new Vector3(0, 0, 0), Quaternion.identity);
    }

    
    void Update()
    {
        if (PlayerScript.HealthPoints <= 0) 
        {
            SceneManager.LoadScene("MenuScene");
            PlayerScript.HealthPoints = 1;
            countActiveEnemies = 0;
            countDeathEnemy = 0;
        }
    }
}
