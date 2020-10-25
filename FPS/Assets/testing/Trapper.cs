using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Trapper : MonoBehaviour
{
    public GameObject trap;
    public Transform cams;
    public LayerMask canTrapPlaced;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            RaycastHit Hit;
            if(Physics.Raycast(cams.position, cams.forward, out Hit, 1000f, canTrapPlaced))
            {
                GameObject trapPlaced = Instantiate(trap, Hit.point + Hit.normal *.001f, Quaternion.identity) as GameObject;
                trapPlaced.transform.LookAt(Hit.point + Hit.normal);
            }
        }

    }
}
