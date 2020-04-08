using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class AircraftControl2 : MonoBehaviour
{
    // First some atribbutes
    //Rotation angle
    private float rSpeed = 120f;
    // Moving speed
    private int mSpeed = 10;
    // For processors
    private float delta;
    // Rigidbody
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
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
    void FixedUpdate()
    {
// Always move forward
	rb.MovePosition(this.transform.position + (transform.forward * mSpeed * Time.fixedDeltaTime));
    }
}
