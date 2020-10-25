using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay (Collider other)
    {

        if (other.CompareTag("player"))
        {

            transform.GetComponent<Animator>().Play("Trap Fire");

            Enemy enemy = other.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamge(dmg);
            }
            //damage player
        }
    }
}
