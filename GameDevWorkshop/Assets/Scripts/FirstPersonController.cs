/***
John Bowditch 2023.09.12 
Script for basic first person character and camera controls

***/


//Libraries that we're using
using System;
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

        characterController = GetComponent<CharacterController>();

        //Hides the mouse cursor at start
        Cursor.lockState = CursorLockMode.Locked;

    }


        // Update is called once per frame
    void Update()
    {
        grounded = characterController.isGrounded;
        MovePlayer();
        Look();
    }

    public void MovePlayer()
    {
        //Direction to move
        Vector3 moveVec = transform.right * moveInput.x + transform.forward * moveInput.y;

        //Move Controller
        characterController.Move(moveVec * speed * Time.deltaTime);

        //Add Gravity
        playerVelocity.y += gravity * Time.deltaTime;

        if (grounded && playerVelocity.y < 0) {

            playerVelocity.y = -2.5f;
        }

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Look()
    {
        float xAmount = mouseMovement.x * sensitivity * Time.deltaTime;
        float yAmount = mouseMovement.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseMovement * sensitivity * Time.deltaTime);

        cam_x_rotation -= xAmount;
        cam_x_rotation = Mathf.Clamp(cam_x_rotation, -90f, 90f);

    }

    public void OnMove(InputAction.CallbackContext context) 
    { 

        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move Input Value: " + moveInput.ToString());
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseMovement = context.ReadValue<Vector2>();
        Debug.Log("Mouse Movement: " + mouseMovement.ToString());

    }

    public void OnJump(InputAction.CallbackContext context)
    {

        Jump();
        Debug.Log("Look ma, I jumped");
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = jumpForce;
        }
    }

}
