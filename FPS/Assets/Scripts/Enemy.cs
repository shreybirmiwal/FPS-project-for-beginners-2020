using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public NavMeshAgent agent;
    public Transform player;


    public void Update()
    {
        agent.SetDestination(player.position);

    }

    public void TakeDamge(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Destroy(gameObject);

        }
    }


}
