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

        if (isMoving)
        {
            lastTimeMoved = Time.time;
            Vector3 movement = new Vector3(x_input, 0, z_input);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    public bool CooldownReady()
    {
        return Time.time - lastTimeMoved > delayMovement;
    }
    public IEnumerator StartMovement()
    {
        yield return new WaitForSeconds(delayMovement);
        isMoving = true;
        StopAllCoroutines();
    }
    public IEnumerator StopMovement()
    {
        yield return new WaitForSeconds(delayMovement);
        isMoving = false;
        StopAllCoroutines();
    }


    // Update is called once per frame
    /*void Update()
    {
        if (onBandeja)
        {
            Vector3 playerMove = player.position - lastPlayerPos;
            transform.Translate(playerMove);
            lastPlayerPos = player.position; 
        }
        
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
        }
    }*/
}
