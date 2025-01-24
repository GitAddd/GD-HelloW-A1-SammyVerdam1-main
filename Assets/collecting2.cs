using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class collecting2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UI;
    public int Collected;
    void Start()
    {
        
    }

    // Update is called once per frame
    

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "coin")
        {
            Collected += 1;
            Debug.Log("Working");

        }
    }
}
