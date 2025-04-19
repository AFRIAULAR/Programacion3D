using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject PrefabBullet; //Bala
    public Transform spawnPoint;    //Punto donde nace la bala

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        //Instantiate(prefabBullet, spawnPoint.position, spawnPoint.rotation); SI se usa object pooler no hace falta instanciar cada vez
       
        //Usando Pool:
        GameObject objeto = ObjectPooler.SharedInstance.GetPooledObject(ObjectType.PrefabBullet);
        objeto.transform.position = spawnPoint.position;
        objeto.transform.rotation = spawnPoint.rotation;
        objeto.SetActive(true);
    }



}
