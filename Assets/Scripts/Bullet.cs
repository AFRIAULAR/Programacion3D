using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifeTimeBullet = 5f;

    void OnEnable() //Se llama cada vez que un objeto se activa en la escena
    {
        // Destroy(gameObject, lifeTimeBullet); //ya no lo necesito si uso pool object
        Invoke("Deactivate", lifeTimeBullet); //Invoke:Llama a un metodo con retraso de tiempo determinado, recibe el metodo y yn float para el tiempo
    }


    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
       // Destroy(this.gameObject); 
       gameObject.SetActive (false);
    }
}
