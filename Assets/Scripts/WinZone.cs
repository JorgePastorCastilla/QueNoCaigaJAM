using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    public GameManager gameManager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.Win();
        }
    }
}
