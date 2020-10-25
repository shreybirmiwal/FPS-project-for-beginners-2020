using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;
    public Transform health;


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
}
