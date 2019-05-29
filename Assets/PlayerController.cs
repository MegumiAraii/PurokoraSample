using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float speed = 3.0f;
    private float gravity = 9.8f;
    float initScaleX = 1.0f;
    bool xDir = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        initScaleX = transform.localScale.x;
    }

    void Update()
    {
        CalculateMove();
    }

    void CalculateMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if ( horizontalInput < -0.3 ){
            xDir = false;
        }

        if (horizontalInput > 0.3 )
        {
            xDir = true;
        }

        if (xDir)
        {
            transform.localScale = new Vector3(initScaleX, transform.localScale.y, transform.localScale.z);
        }else{
            transform.localScale = new Vector3(initScaleX*-1.0f, transform.localScale.y, transform.localScale.z);
        }

        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        // Debug.Log(direction);

        Vector3 velocity = direction * speed;
        // velocity.y -= gravity;
        // velocity = transform.transform.TransformDirection(velocity);

        // Debug.Log(velocity);
        //controller.Move(velocity * Time.deltaTime);

        GetComponent<Rigidbody>().velocity = velocity;
    }
}