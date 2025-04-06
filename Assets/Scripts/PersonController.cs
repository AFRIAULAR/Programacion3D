using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    [Header("Character Movement")] //Tag para identificar variables en inspector
    public float speed = 5f;
    public CharacterController characterController;

    [Header("Camera Movement")]
    public Transform cameraTransform;
    public float mouseSensitivityX = 2f;
    public float mouseSensitivityY = 2f;
    private float verticalRotation = 0f;
    void Update()
    {
        MovePlayer();
        MoveCamera();
    }

    void MovePlayer()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

       // transform.Translate(movX, 0, movY); --> Vector3: X Y Z
       Vector3 movement = transform.right * movX + transform.forward * movY;

       characterController.Move(movement * speed * Time.deltaTime);
    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        //CLAMP (rango de alcance de la camara)
        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation,0,0f); //rotacion vertical para mover la camara, arrastrar camara al script en inspector para que funcione
        transform.Rotate(Vector3.up * mouseX);
    }
}
 