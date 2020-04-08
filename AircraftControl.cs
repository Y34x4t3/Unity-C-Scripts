using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftControl : MonoBehaviour
{
    //This scripts makes it posible to control an aircraft
    private int forwardSpeed = 2;
    private float SidewaysSpeed = 1.0f;
    private float angle = 45.0f;

    private Quaternion originalRotation; //In order to get the original rotation
    
    void Start()
    {
        originalRotation = transform.rotation; // Initial Rotation
    }

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * forwardSpeed, Space.World); //Move forward. Always moving forward
        if ((Input.GetKeyUp(KeyCode.UpArrow)) && (Input.GetKeyUp(KeyCode.DownArrow)) && (Input.GetKeyUp(KeyCode.RightArrow)) && (Input.GetKeyUp(KeyCode.LeftArrow)))// Restart rotation
        {
            transform.rotation = originalRotation;
        }
         if (Input.GetKeyDown(KeyCode.UpArrow)) //Rotates negatively in the x axis && Moves up
        {
            this.transform.Rotate(new Vector3(-angle, 0, 0));
            this.transform.Translate(Vector3.up * SidewaysSpeed, Space.World);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) // Rotates positively in x axis && Moves down
        {
            this.transform.Rotate(new Vector3(angle, 0, 0));
            this.transform.Translate(Vector3.down * SidewaysSpeed, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // Rotates positively in y axis && Moves right
        {
            this.transform.Rotate(new Vector3(0, angle, 0));
            this.transform.Translate(Vector3.right * SidewaysSpeed, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // Rotates negatively in y axis && Moves left
        {
            this.transform.Rotate(new Vector3(0, -angle, 0));
            this.transform.Translate(Vector3.left * SidewaysSpeed, Space.World);
        }
     }
}
