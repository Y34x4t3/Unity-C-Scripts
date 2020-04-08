using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Animator animator_component;
    //Running
    private bool runn_ng;
    // Jumping
    private bool jum_;
    // WalkingFront
    private bool walk_ngf;
    //Crouch
    private bool crou_h;
    //Dancing
    private bool danc_ng;
    //RotateRight
    private bool rotater;
    //RotateLeft
    private bool rotatel;
    //WalkingBackwards
    private bool walk_ngb;
    // Rotation speed
    private int rotationSpeed = 3;
    //Just a help variable
    private float rotationMagnitude;
    //Translation speed
    private int tSpeed = 1;
    //Rotation
    private Vector3 rotationVector;
    // The rigidbody
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //I get access to the animation controller
        animator_component = gameObject.GetComponent<Animator>();
        // I get access to the rigidbody
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
//In case was running before
        tSpeed = 1;
        //If pressing f
        if (Input.GetKeyDown(KeyCode.F))
        {
            danc_ng = true;
            Debug.Log("Presionando F");
        }
        //If not pressing A
        if (Input.GetKeyUp(KeyCode.F))
        {
            danc_ng = false;
            Debug.Log("No presionando F");
        }
        //If pressing w
        if (Input.GetKeyDown(KeyCode.W))
        {
            walk_ngf = true;
            Debug.Log("Presionando W");
        }
        //If not pressing w
        if (Input.GetKeyUp(KeyCode.W))
        {
            walk_ngf = false;
            Debug.Log("No presionando W");
        }
        //If pressing s
        if (Input.GetKeyDown(KeyCode.S))
        {
            walk_ngb = true;
            Debug.Log("Presionando S");
        }
        //If not pressing s
        if (Input.GetKeyUp(KeyCode.S))
        {
            walk_ngb = false;
            Debug.Log("No presionando S");
        }
        //If pressing d
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotater = true;
            Debug.Log("Presionando D");
        }
        //If not pressing d
        if (Input.GetKeyUp(KeyCode.D))
        {
            rotater = false;
            Debug.Log("No presionando D");
        }
        //If pressing tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            crou_h = true;
            Debug.Log("Presionando tab");
        }
        //If not pressing tab
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            crou_h = false;
            Debug.Log("No presionando tab");
        }
        //If pressing A
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotatel = true;
            Debug.Log("Presionando A");
        }
        //If not pressing A
        if (Input.GetKeyUp(KeyCode.A))
        {
            rotatel = false;
            Debug.Log("No presionando A");
        }
        //If pressing shift
        if ((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)))
        {
            runn_ng = true;
            Debug.Log("Presionando Shift");
        }
        //If not pressing shift
        if ((Input.GetKeyUp(KeyCode.LeftShift)) || (Input.GetKeyUp(KeyCode.RightShift)))
        {
            runn_ng = false;
            Debug.Log("No presionando Shift");
        }
        //If pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jum_ = true;
            Debug.Log("Presionando space");
        }
        //If not pressing space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jum_ = false;
            Debug.Log("No presionando space");
        }
        //Update values
        if (walk_ngf)
            animator_component.SetBool("walking", true);
        else if (!walk_ngf)
            animator_component.SetBool("walking", false);
        if (danc_ng)
            animator_component.SetBool("dancing", true);
        else if (!danc_ng)
            animator_component.SetBool("dancing", false);
        if (walk_ngb)
            animator_component.SetBool("walkingb", true);
        else if (!walk_ngb)
            animator_component.SetBool("walkingb", false);
        if (crou_h)
            animator_component.SetBool("crouch", true);
        else if (!crou_h)
            animator_component.SetBool("crouch", false);
        if (jum_)
            animator_component.SetBool("jump", true);
        else if (!jum_)
            animator_component.SetBool("jump", false);
        if (runn_ng)
            animator_component.SetBool("running", true);
        else if (!runn_ng) 
            animator_component.SetBool("running", false);
        //
        if (rotatel || rotater)
        {
            // For processor settings
             rotationMagnitude = rotationSpeed;// * Time.deltaTime;
            //Rotation
            rotationVector = Vector3.up * rotationMagnitude;
            //
            if (rotatel && walk_ngf)
                this.transform.Rotate(Vector3.up * (rotationMagnitude*-1), Space.Self);
            else if (rotater && walk_ngf)
                this.transform.Rotate(rotationVector, Space.Self);	
            if (walk_ngb)
            {
		tSpeed *=-1;
		if (rotatel)
                    this.transform.Rotate(rotationVector, Space.Self);
                if (rotater)
                    this.transform.Rotate(Vector3.up *(rotationMagnitude*-1), Space.Self);
            }
        }   
	if (walk_ngb)
            tSpeed *= -1;
        if (runn_ng && !walk_ngb)
            tSpeed *= 3;
        // If is walking
        if (walk_ngf || walk_ngb)
            rb.MovePosition(this.transform.position + (transform.forward * tSpeed * Time.fixedDeltaTime));
    }
}
