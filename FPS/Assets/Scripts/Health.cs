using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public Transform health;
    public LayerMask enemy;

    public void Start()
    {
        InvokeRepeating("CheckZombie", 2f, 2f);
    }
    void RefreshHealthBar()
    {
        float healthRatio = currHealth / maxHealth;
        health.localScale = Vector3.Lerp(health.localScale, new Vector3(healthRatio, 1, 1), Time.deltaTime * 8f);
            
    }
    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        if(currHealth <= 0)
        {
            //dying animation
        }
    }
    public void Update()
    {
        RefreshHealthBar();
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }

    }
    void CheckZombie()
    {
        if(Physics.CheckSphere(transform.position, 1f, enemy))
        {
            TakeDamage(5);

        }
    }

}
