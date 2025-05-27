using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x_input = Input.GetAxis("Horizontal");
        float z_input = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(x_input, 0, z_input);
        controller.Move(movement * speed * Time.deltaTime);
        // rb.MovePosition( transform.position + movement * speed * Time.deltaTime);
        //transform.Translate(movement * speed * Time.deltaTime);
        
    }
    
    
}
