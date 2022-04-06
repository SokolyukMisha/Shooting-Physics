using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float range = 20f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] Canvas canvas;
    [SerializeField] Camera fpsCam;
    [SerializeField] ParticleSystem muzzelFlash;
    [SerializeField] GameObject hitEffect;

    private Recoil recoil;  

    private float nextTimeToFire = 0f;
    private void OnEnable()
    {
        canvas.gameObject.SetActive(true);
    }
    private void Start()
    {
        recoil = transform.GetComponentInParent(typeof(Recoil)) as Recoil;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        recoil.RecoilFire();
        muzzelFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            target target = hit.transform.GetComponent<target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
           GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
           Destroy(impact, 15f);
        }
    }
}
