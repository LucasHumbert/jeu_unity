﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("Player")) {

            PlayerHealth playerHealth = col.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(50);

        }

    }


}
