using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int ClipAmmo = 3;
    public int MaxAmmo = 10;
    public int MacClip;
    public GameObject CurrentWeapon;
    private bool isReloading = false;
    private bool CanShoot = true;
    private int ammoDifference;
    public Text ammoUi;
    public Transform cams;

    public float Damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        MacClip = ClipAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseActions();
        CheckReload();
        updateUI();
    }
    void CheckMouseActions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(ClipAmmo > 0)
            {
                Fire();
            }
            else if (ClipAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
            
        }
    }
    void Fire()
    {
        if(ClipAmmo > 0 && CanShoot)
        {
            CurrentWeapon.GetComponent<Animator>().Play("Shooting");
            
            ClipAmmo = ClipAmmo - 1;

            RaycastHit Hit;
            if(Physics.Raycast(cams.position, cams.forward, out Hit, 1000f))
            {

                Debug.LogError(Hit.transform.name);
                Enemy enemy = Hit.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamge(Damage);
                }
                
            }
        }
        
    }
    void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CanShoot = false;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        CanShoot = false;
        CurrentWeapon.GetComponent<Animator>().Play("Reloading");

        yield return new WaitForSeconds(2.7f);

        if(ClipAmmo == 0)
        {
            if (MaxAmmo >= MacClip)
            {
                ClipAmmo = MacClip;
                MaxAmmo = MaxAmmo - MacClip;
            }
            else
            {
                Debug.Log("not enough bullets to reload");
            }
        }
        else
        {
            ammoDifference = MacClip - ClipAmmo;
            if (MaxAmmo < ammoDifference)
            {
                Debug.Log("not enough to reload");
            }
            else
            {
                ClipAmmo = ClipAmmo + ammoDifference;
                MaxAmmo = MaxAmmo - ammoDifference;
            }
        }
        CanShoot = true;

    }
    void updateUI()
    {
        ammoUi.text = (ClipAmmo + "/" + MaxAmmo);
    }


}
