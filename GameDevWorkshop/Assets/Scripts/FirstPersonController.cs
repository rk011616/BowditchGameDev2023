/***
John Bowditch 2023.09.12 
Script for basic first person character and camera controls

***/


//Libraries that we're using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{

    //Player Variables
    public float speed = 2.0f;
    public float gravity = -10.0f;
    public float jumpForce = 2.0f;

    //Movement and Looking Variables
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 playerVelocity;
    private bool grounded;
    private Vector2 mouseMovement;

    //Camera Variables
    public Camera cameraLive;
    public float sensitivity = 25.0f;
    private float cam_x_rotation;


    // Start is called before the first frame update
    void Start()
    {

    }


        // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context) 
    { 
    
    }

    public void OnLook(InputAction.CallbackContext context)
    {
            
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }
}
