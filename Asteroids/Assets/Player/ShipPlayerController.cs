//Ship Controller Script - bowditch 20231019

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipPlayerController : MonoBehaviour
{
    //Input
    private Vector2 move_input;

    //Player Variables

    public float move_force;
    public float rotate_speed;
    private Rigidbody rigidbody;

    //Screen Wrap
    public Camera camera;
    public Plane[] camera_frustum;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(move_input);
        RotatePlayer();

        MovePlayer();

    }

    public void GetMoveInput(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();

    }

    private void MovePlayer()
    {
        if (move_input.y == 1) {

            rigidbody.AddForce(transform.forward * move_force, ForceMode.Force);
            
        }  
    }

    private void RotatePlayer()
    {
        transform.Rotate(Vector3.up, move_input.x * rotate_speed * Time.deltaTime, Space.Self);
    }

    private void ScreenWrap()
    {

    }
}
