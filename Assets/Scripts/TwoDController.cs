using UnityEngine;
using System.Collections;

public class TwoDController : MonoBehaviour {
	public float speed, maxSpeed, jumpForce;

	private Transform groundCheck;
	private bool left, right, grounded, jump;

	void Awake(){
		groundCheck = transform.Find("GroundCheck");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		//movement left and right
		if(Input.GetAxis("Horizontal") > 0){
			right = true;
		}
		if(Input.GetAxis("Horizontal") < 0){
			left = true;
		}
		if(Input.GetAxis("Horizontal") == 0){
			left = false; right = false;
		}

		//jumping 
		if(Input.GetButtonDown("Jump") && grounded){
			jump = true;
		}
		if(!grounded)
			jump = false;
	}

	void FixedUpdate(){

		//check out direction and apply force depending on it
		if(left && ( rigidbody2D.velocity.x  > -maxSpeed ))
			rigidbody2D.AddForce(Vector2.right * -1 * speed);
		if(right && ( rigidbody2D.velocity.x  < maxSpeed ))
			rigidbody2D.AddForce(Vector2.right * speed);

		// if you are going to fast, set you to max speed
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		// jump time
		if(jump)
			rigidbody2D.AddForce(Vector2.up * jumpForce);

	}


}
