using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class physicsMovement : MonoBehaviour
{
    // A SerializeField makes a private variable visible in Unity but it's still not seen by any other compoment since it's private.  
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float raycast;
    private float runSpeed = 10f;
    private float crouchHeight = 0.5f;
    
    private Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Crouch();
        
    }

    private void FixedUpdate() // A fixed update calls only physics based gameobjects
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0, z) * speed * Time.fixedDeltaTime;
        Vector3 newPos = rb.position + rb.transform.TransformDirection(move);
        rb.MovePosition(newPos);

        if (Input.GetKey(KeyCode.LeftControl)) // Running
        {
            //Sprinting();
            Sprint();
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);    
            }
        }
        
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycast);
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isGrounded())
            {
                //crouch = true;
                transform.localScale = new Vector3(1f, crouchHeight, 1f);
                
            }
        }
        else
        {
            //crouch = false;
            transform.localScale = new Vector3(1f, crouchHeight * 2, 1f);
        }
        
    }

    private void Sprint()
    {
        transform.Translate(transform.forward * runSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime, Space.World);
    }
}
// Raycast creates a invisible line and it checks if it collides with anything.