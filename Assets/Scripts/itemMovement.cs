using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMovement : MonoBehaviour
{
    public Transform player;

    // private Vector3 lastPlayerPos;
    // // Start is called before the first frame update
    // public bool onBandeja = false;
    public float speed = 5f;
    public bool isMoving = false;
    public float delayMovement = 0.1f;
    public float lastTimeMoved = 0;

    public Vector3 lastPosition;
    public bool onBandeja = false;
    
    public GameManager gameManager;
    void Start()
    {
        // lastPlayerPos = player.position;
    }

    private void Update()
    {
        float x_input = Input.GetAxis("Horizontal");
        float z_input = Input.GetAxis("Vertical");

        if ( (x_input != 0 || z_input != 0) && !isMoving)
        {
            if (CooldownReady())
            {
                isMoving = true;
                lastTimeMoved = Time.time;
            }
        }

        if ( (x_input == 0 && z_input == 0) && isMoving )
        {
            if (CooldownReady())
            {
                isMoving = false;
            }
        }
        
        if (isMoving && onBandeja)
        {
            lastTimeMoved = Time.time;
            // if (player.position.x == lastPosition.x)
            // {
            //     x_input = 0;
            // }
            // if (player.position.z == lastPosition.z)
            // {
            //     z_input = 0;
            // }
            Vector3 movement = new Vector3(x_input, 0, z_input);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        lastPosition = player.position;
        
    }

    public bool CooldownReady()
    {
        return Time.time - lastTimeMoved > delayMovement;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bandeja")
        {
            onBandeja = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bandeja")
        {
            onBandeja = false;
            gameManager.GameOver();
        }
    }
}
