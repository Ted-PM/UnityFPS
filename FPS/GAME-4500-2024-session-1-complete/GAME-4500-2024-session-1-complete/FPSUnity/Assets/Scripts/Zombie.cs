using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public float walkingSpeed;
    public float maxHealth;
    float currentHealth;
    //public float attackDamage;

    public GameObject gutsPrefab;
    public GameObject babyGutsPrefab;

    public Image healthBarFill;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();       //
        currentHealth = maxHealth;
    }

    void Update()
    {
        ChasePlayer();


    }


    void ChasePlayer()
    {
        agent.destination = target.position;
    }

    public void TakeDamage(float damageToTake)        // public for projectile script 
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            Instantiate(gutsPrefab, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(babyGutsPrefab, transform.position, Quaternion.identity, null);
            healthBarFill.fillAmount = currentHealth / maxHealth;

        }
    }

    public void GiveDamage()
    {



    }
}
