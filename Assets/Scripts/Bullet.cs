using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifeTimeBullet = 5f;

    void Start()
    {
        // Destroy(gameObject, lifeTimeBullet); //ya no lo necesito si uso pool object
    }


    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
       // Destroy(this.gameObject); 
    }
}
