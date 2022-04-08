using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    private void OnCollisionEnter(Collision collision)
    {        
        GameObject impact = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(impact, 2f);
    }
}
