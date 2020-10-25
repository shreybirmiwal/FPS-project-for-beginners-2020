using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activation : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator fire(Collider other2)
    {
        transform.GetComponent<Animator>().Play("Spike");

        yield return new WaitForSeconds(2.117f);
        if (other2 != null)
        {
            Enemy enemy = other2.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamge(damage);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(fire(other));
        }
    }
}
