using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMovement : MonoBehaviour
{
    public Transform player;

    private Vector3 lastPlayerPos;
    // Start is called before the first frame update
    public bool onBandeja = false;
    
    void Start()
    {
        lastPlayerPos = player.position;
    }

    // Update is called once per frame
    void Update()
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
    }
}
