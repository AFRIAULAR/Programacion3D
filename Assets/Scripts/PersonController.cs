using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float speed = 5f;
   public CharacterController characterController;
    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

       // transform.Translate(movX, 0, movY); --> Vector3: X Y Z
       Vector3 movement = transform.right * movX + transform.forward * movY;

       characterController.Move(movement * speed * Time.deltaTime);
    }
}
