using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    
    public void TakeDamge(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Destroy(gameObject);

        }
    }

}
