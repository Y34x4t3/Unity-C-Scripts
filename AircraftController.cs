using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftControl2 : MonoBehaviour
{
    // First some atribbutes
    //Rotation angle
    private float rSpeed = 120f;
    // Moving speed
    private int mSpeed = 10;
    // For processors
    private float delta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
        // Always move forward
        this.transform.Translate(Vector3.forward * mSpeed, Space.Self);
        // If pressing right arrow
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.Rotate(Vector3.back * (rSpeed * delta), Space.Self);
        // If pressing left arrow
        else if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.Rotate(Vector3.forward * (rSpeed * delta), Space.Self);
        // If pressing down arrow
        if (Input.GetKey(KeyCode.DownArrow))
            this.transform.Rotate(Vector3.right * (rSpeed * delta), Space.Self);
        // If pressing up arrow
        if (Input.GetKey(KeyCode.UpArrow))
            this.transform.Rotate(Vector3.left * (rSpeed * delta), Space.Self);
    }
}
