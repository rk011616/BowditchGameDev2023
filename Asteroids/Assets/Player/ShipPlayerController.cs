//Ship Controller Script - bowditch 20231019

using JetBrains.Annotations;
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

    //Debug
    public GameObject test_cube1;
    public GameObject test_cube2;
    public GameObject test_cube3;
    public GameObject test_cube4;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();

        //Get planes from camera frustum
        camera_frustum = GeometryUtility.CalculateFrustumPlanes(camera);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(move_input);
        RotatePlayer();

        MovePlayer();

        ScreenWrap();

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
        //Wrap Variables
        float radius = 2;
        Vector3 bottom_point = transform.position - new Vector3(0, 0, radius);
        Vector3 top_point = transform.position + new Vector3(0, 0, radius);
        Vector3 right_point = transform.position + new Vector3(radius, 0, 0);
        Vector3 left_point = transform.position - new Vector3(radius, 0, 0);
        float distance_to_camera;

        //Debug Variables

        test_cube1.transform.position = bottom_point;
        test_cube2.transform.position = top_point;
        test_cube3.transform.position = right_point;
        test_cube4.transform.position = left_point;

        //Top Plane
        if (!camera_frustum[3].GetSide(bottom_point))
        {
            //Finding the distance the player is from camera
            distance_to_camera = transform.position.z - camera.transform.position.z;
            
            //Positioning player based off distance
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (distance_to_camera * 2) + 1f);
        }

        //Bottom Plane
        if (!camera_frustum[2].GetSide(top_point))
        {
            //Finding the distance the player is from camera
            distance_to_camera = camera.transform.position.z - transform.position.z;

            //Positioning player based off distance
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (distance_to_camera * 2) - 1f);
        }

        //Left Plane
        if (!camera_frustum[0].GetSide(right_point))
        {
            distance_to_camera = camera.transform.position.x - transform.position.x;

            transform.position = new Vector3(transform.position.x + (distance_to_camera * 2) - 1f, transform.position.y, transform.position.z);
        }

        //Right Plane
        if (!camera_frustum[1].GetSide(left_point))
        {
            distance_to_camera = transform.position.x - camera.transform.position.x;

            transform.position = new Vector3(transform.position.x - (distance_to_camera * 2) + 1f, transform.position.y, transform.position.z);
        }
    }
}
