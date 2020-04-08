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
    private float rotationSpeed = 0.9f;
    //Just a help variable
    private float rotationMagnitude;
    //Translation speed
    private float tSpeed = 0.00999f;
    //Rotation
    private Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        //I get access to the animation controller
        animator_component = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //In case was running before
        tSpeed = 0.00999f;
        //If pressing f
        if (Input.GetKeyDown(KeyCode.F))
        {
            danc_ng = true;
        }
        //If not pressing A
        if (Input.GetKeyUp(KeyCode.F))
        {
            danc_ng = false;
        }
        //If pressing w
        if (Input.GetKeyDown(KeyCode.W))
        {
            walk_ngf = true;
        }
        //If not pressing w
        if (Input.GetKeyUp(KeyCode.W))
        {
            walk_ngf = false;
        }
        //If pressing s
        if (Input.GetKeyDown(KeyCode.S))
        {
            walk_ngb = true;
        }
        //If not pressing s
        if (Input.GetKeyUp(KeyCode.S))
        {
            walk_ngb = false;
        }
        //If pressing d
        if (Input.GetKeyDown(KeyCode.D))
        {
            rotater = true;
        }
        //If not pressing d
        if (Input.GetKeyUp(KeyCode.D))
        {
            rotater = false;
        }
        //If pressing tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            crou_h = true;
        }
        //If not pressing tab
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            crou_h = false;
        }
        //If pressing A
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotatel = true;
        }
        //If not pressing A
        if (Input.GetKeyUp(KeyCode.A))
        {
            rotatel = false;
        }
        //If pressing shift
        if ((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)))
        {
            runn_ng = true;
        }
        //If not pressing shift
        if ((Input.GetKeyUp(KeyCode.LeftShift)) && (Input.GetKeyUp(KeyCode.RightShift)))
        {
            runn_ng = false;
        }
        //If pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jum_ = true;
        }
        //If not pressing space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jum_ = false;
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
        if (walk_ngb)
            tSpeed *=-1;
        if (runn_ng)
            tSpeed *= 1.8f;
        // If is walking
        if (walk_ngf || walk_ngb)
            this.transform.Translate(Vector3.forward * tSpeed, Space.Self);
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
            else if (rotatel && walk_ngb)
                this.transform.Rotate(rotationVector, Space.Self);
            else if (rotater && walk_ngb)
                this.transform.Rotate(Vector3.up *(rotationMagnitude*-1), Space.Self);
        }
    } 
}
