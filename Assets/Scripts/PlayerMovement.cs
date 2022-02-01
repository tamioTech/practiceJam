using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform crosshair;
    [SerializeField] float xMaxSpeed = 10f;
    [SerializeField] float yMaxSpeed = 10f;
    [SerializeField] float dashSpeed = 2f;
    [SerializeField] Vector3 crosshairOffset;
    [SerializeField] Transform arm;

    float lerpTime = 1f;
    Vector3 distFromPlayer;
    Vector3 dfpNorm;
    float ang;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
        Dash();
        CrosshairPosition();
        ang = Mathf.Atan2(dfpNorm.y, dfpNorm.x) * Mathf.Rad2Deg;
        if(ang<0)
        {
            ang += 360;
        }
        //print(ang);
        arm.transform.eulerAngles = new Vector3(0, 0, ang); 
    }

    private void CrosshairPosition()
    {
        distFromPlayer = MousePosition() - rb.transform.position;
        dfpNorm = distFromPlayer.normalized;
        //print(dfpNorm);
        crosshair.position = rb.transform.position + dfpNorm + crosshairOffset;
    }

    private static Vector3 MousePosition()
    {
        Vector3 worldToScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldToScreen.z = 0f;
        
        return worldToScreen;
    }

    private void InputHandler()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        float xSpeed = xMaxSpeed * xAxis;
        float ySpeed = yMaxSpeed * yAxis;

        if(lerpTime < 1) { lerpTime *= 0.2f; }
        xSpeed = Mathf.Lerp(rb.velocity.x, xSpeed, lerpTime);
        ySpeed = Mathf.Lerp(rb.velocity.y, ySpeed, lerpTime);

        rb.velocity = new Vector2(xSpeed, ySpeed); 

    }

    private void Dash()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }
        
        //print("DASHHHHH");
        rb.AddForce(rb.velocity * dashSpeed);
    }


}
