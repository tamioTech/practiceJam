using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float xMaxSpeed = 10f;
    [SerializeField] float yMaxSpeed = 10f;

    float lerpTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        float xSpeed = xMaxSpeed * xAxis;
        float ySpeed = yMaxSpeed * yAxis;

        if(lerpTime < 1) { lerpTime *= 0.2f; }
        print("lerpTime: " + lerpTime);
        xSpeed = Mathf.Lerp(rb.velocity.x, xSpeed, lerpTime);
        ySpeed = Mathf.Lerp(rb.velocity.y, ySpeed, lerpTime);

        rb.velocity = new Vector2(xSpeed, ySpeed); 

    }
}
