using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{

    public Light light;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {

        if(context.phase == InputActionPhase.Started)
        {

       
        //Simple Enable/Disable statement
        //light.enabled = !light.enabled;

        //Random Color Range selector
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        light.color = new Color(r, g, b);

        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.Play();

        }
    }

}
