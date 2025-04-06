using System.Collections;
using System.Collections.Generic;
using System.Threading;
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


    // DETECTAR TOUCH
    private Vector2 lastTouchPosition;
    private bool isTouching = false;

    void Update()
    {
        MovePlayer();
        MoveCameraMouse();
        
        if(Input.touchCount >0)
        MoveCameraTouch();
    }

    void MovePlayer()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

       // transform.Translate(movX, 0, movY); --> Vector3: X Y Z
       Vector3 movement = transform.right * movX + transform.forward * movY;

       characterController.Move(movement * speed * Time.deltaTime);
    }

        // MOVER CAMARA CON MOUSE
    void MoveCameraMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;
        
        ApplyRotation(mouseX, mouseY);
    
        //    CLAMP (rango de alcance de la camara)
        //    verticalRotation += mouseY;
        //    verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f);

        //    Rotacion vertical:
        //    cameraTransform.localRotation = Quaternion.Euler(verticalRotation,0,0f);
        //    Rotacion horizontal:
        //    transform.Rotate(Vector3.up * mouseX); //vector3.up indica el eje alrededor del cual se rota (eje x)
        //
    }

        // DETECTAR TOUCHES
    void MoveCameraTouch()
    {
        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began) //pregunta si se toco la pantalla y guarda la posicion
        {
            lastTouchPosition = touch.position;
            isTouching = true;
        }
        //estoy moviendo el dedo???
        else if(touch.phase == TouchPhase.Moved && isTouching)
        {
            float posX = touch.deltaPosition.x * mouseSensitivityX;
            float posy = touch.deltaPosition.y * mouseSensitivityY;
           ApplyRotation(posy, posX);
            
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            isTouching = false;
            Debug.Log("DEJASTE DE TOCAR");
        }
    }
        
        
        // MOVER CAMARA EN PC Y MOBILE
    void ApplyRotation(float horizontal, float vertical)
    {
        verticalRotation -= vertical;
        verticalRotation = Mathf.Clamp(verticalRotation, -45, 45);
        
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(Vector3.up * horizontal);

    }

  }
 