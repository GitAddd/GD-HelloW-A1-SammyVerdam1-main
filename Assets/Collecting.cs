using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
    public int collected;
    [SerializeField] Text ui;


    private void Update()
    {
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            collected += 1;
            ui.text = collected.ToString();

        }
    }
}
