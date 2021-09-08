using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnEnemyScript : MonoBehaviour
{
    public GameObject enemyGameObject;

    private float timeDelaySpawn = 2.000f;
    private int maxEnemies = 10;

    private int minValueSpownX = -8;
    private int maxValueSpownX = 9;
    private int minValueSpownY = -22;
    private int maxValueSpownY = 16;
    private int minValueSpownZ = -100;
    private int maxValueSpownZ = -111;

    public void Spawn() 
    {
        GameControllerScript.countActiveEnemies++;
        Instantiate(
            enemyGameObject, transform.position + new Vector3(
                Random.Range(minValueSpownX, maxValueSpownX),
                Random.Range(minValueSpownY, maxValueSpownY),
                Random.Range(minValueSpownZ, maxValueSpownZ)),
            Quaternion.identity);
    }

    IEnumerator SpawnEnemy() 
    {
        while (true)
        {
            if ((PlayerScript.HealthPoints <= 0) || (GameControllerScript.countActiveEnemies >= maxEnemies)) break;

            yield return new WaitForSeconds(timeDelaySpawn);
            Spawn();

            timeDelaySpawn = timeDelaySpawn > 0 ? timeDelaySpawn -= 0.050f : 0;
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
}
