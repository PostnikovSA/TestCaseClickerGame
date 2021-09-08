using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class StoneMonsterScript : MonoBehaviour, IPointerClickHandler
{
    public int HealthPoints { get; set; } = 1;
    public int AttackPower { get; set; } = 1;
    public int DefencePower { get; set; } = 0;

    private int _dyingTimeEnemy = 300;
    private int _maxEnemies = 10;

    public GameObject targetObject;

    public int TakeDamage()
    {
        int damage = PlayerScript.AttackPower - DefencePower;
        damage = damage > 0 ? PlayerScript.AttackPower - DefencePower : 0;
        return damage;
    }
    public void Fall(GameObject gameObject) 
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        static int TorqueRandomSide() => Random.Range(-90, 91);
        rb.AddTorque(TorqueRandomSide(), TorqueRandomSide(), TorqueRandomSide());
    }
    public void Die(GameObject gameObject) 
    {
        Destroy(gameObject, _dyingTimeEnemy);

        GameControllerScript.countDeathEnemy++;
        GameControllerScript.countActiveEnemies--;

        if (GameControllerScript.maxKilledEnemies < GameControllerScript.countDeathEnemy)
            GameControllerScript.maxKilledEnemies = GameControllerScript.countDeathEnemy;
    }
    public void Attack()
    {
        if (GameControllerScript.countActiveEnemies >= _maxEnemies)
            PlayerScript.HealthPoints = PlayerScript.HealthPoints + PlayerScript.DefencePower - AttackPower;
    }



    public void Start()
    {
        Attack();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerScript.HealthPoints > 0)
        {
            if (HealthPoints > 0)
            {
                HealthPoints -= TakeDamage();

                if (HealthPoints <= 0)
                {
                    Fall(gameObject);
                    Die(gameObject);
                }
            }
        }
    }
}
