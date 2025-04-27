using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    //público para que pueda ser visto 
    //static para que pueda ser accedido
    void Awake()
    {
        if (Instance == null) //Nulo? ->nueva copia
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //hay copia-> destroy
        {
            Destroy(this);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
