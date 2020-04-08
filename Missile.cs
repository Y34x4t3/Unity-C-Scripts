using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour
{
// Rigidbody
    private Rigidbody rb;
// Moving speed
    private int speed = 17;
// Know if has to move
    private bool move; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
// Moves the GameObject using it's transform.
        rb.isKinematic = true;
    }
    void Update()
    {
	// If presses space, launch missile
        if (Input.GetKeyDown(KeyCode.Space))
 	    move= true;
    }
    //Physics stuff
    void FixedUpdate()
    {
	if (move)
	    //Move the rigidbody
    	    rb.MovePosition(this.transform.position + (transform.forward * speed * Time.fixedDeltaTime));
    }
}
