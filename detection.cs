using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    public float hoverForce = 12f;
    
    //Colliders
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("The Sphere Entered The Castle");
        other.attachedRigidbody.AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
