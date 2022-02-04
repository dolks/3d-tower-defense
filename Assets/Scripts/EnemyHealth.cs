using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int health = 5;
    [SerializeField] int difficultyRamp = 1;
    Enemy enemy;
    int startingHealth = 5;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        enemy.RewardGold();
        health = startingHealth + difficultyRamp;
        difficultyRamp++;
    }
}
