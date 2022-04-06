using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    GrenadeShoot grenade;
    [SerializeField] GameObject hitEffect;

    void Start() {   
        grenade = GetComponent<GrenadeShoot>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject impact = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(impact, 15f);
    }
}
