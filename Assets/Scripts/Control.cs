using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public GameObject maincam;
    private Rigidbody rb;
    public float maxSpeed = 40.0f;
    public float regSpeed = 2.0f;
    public float jumpSpeed = 50.0f;
    private bool onGround = true;
    private bool isJumping = false;
    private int playerHealth;
	// Use this for initialization

	private float nextTime = 0;
	public int interval = 1;

	void Start () {
        maincam = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {

        //Move camera with right, not left
        if (Input.GetKey(KeyCode.D)) rb.AddForce(Vector3.right * regSpeed);//rb.velocity = rb.velocity + (Vector3.right * regSpeed);
        else if (Input.GetKey(KeyCode.A)) rb.AddForce(Vector3.left * regSpeed); //rb.velocity = rb.velocity + (Vector3.left * regSpeed);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //rb.velocity = rb.velocity + (Vector3.up * jumpSpeed);
            rb.AddForce(Vector3.up * jumpSpeed); //Need a separate jump speed for this, as well as a double-jump check.
            onGround = false;
            isJumping = true;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            //rb.velocity = rb.velocity + (Vector3.up * jumpSpeed);
            rb.AddForce(Vector3.up * jumpSpeed);
            isJumping = false;
        }


        //Sprint using Ctrl
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) maxSpeed *= 3.0f;
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl)) maxSpeed /= 3.0f;


        //Code below to ensure a maxspeed works.  Ie if maxspeed is reached, on every update, push back the same force.
		if (Time.time >= nextTime) {
			Debug.Log ("Speed = " + rb.velocity);
			nextTime += interval;
		}
        
        if (rb.velocity.x > maxSpeed)
        {
			Debug.Log ("1 if");
            //rb.velocity = rb.velocity.normalized * maxSpeed; //Has max speed.  Affects jump velocity, though...
			rb.AddForce(Vector3.left * regSpeed);
		}
		if (rb.velocity.x < maxSpeed * -1)
		{
			Debug.Log ("2 if");
			//rb.velocity = rb.velocity.normalized * maxSpeed; //Has max speed.  Affects jump velocity, though...
			rb.AddForce(Vector3.right * regSpeed);
		}
    }


    //If player collides with platform, they are on "ground" and are not jumping.  This does not factor in side of platforms.  Ergo, wall jumping is
    //a possibility.  Can be fixed by adding a plane on top of platforms and testing for THEIR collision instead.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            onGround = true; //Reset double jump on land.
            isJumping = false;
        }
        switch (collision.gameObject.tag)
        {
            case "EnemySpikey":
                playerHealth -= 20;
                rb.AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity * -1); //Opposite direction?
                break;
            case "Platforms":
                break;
            default:
                rb.AddForce(Vector3.up * 20.0f); //?
                break;
        }
    }

    //When leaving a platform by means other than jumping, make sure to check off that they are in the air.  That way, no one can double jump by
    //sliding off of a platform.  They may only single jump once in the air.
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platforms")
        {
            onGround = false;
            isJumping = true;
        }
    }
}
