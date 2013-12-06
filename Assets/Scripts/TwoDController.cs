using UnityEngine;
using System.Collections;

public class TwoDController : MonoBehaviour {
	public float speed, maxSpeed;
    public float jumpSpeed;

    public Jump jumpThing;

	private Transform groundCheck;
	private bool left, grounded, jump;
    private bool right = true;

    public bool jumping = false;

	void Awake(){
		groundCheck = transform.Find("GroundCheck");
	}
	// Use this for initialization
	void Start () {

	}

    public void JumpAI(float xSpeed) {
        rigidbody2D.velocity = new Vector2(xSpeed, jumpSpeed);
    }

	// Update is called once per frame
	void Update () {

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

        /*
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
         */
	}

	void FixedUpdate(){
        if (!jumping) rigidbody2D.velocity = new Vector2(5.0f, rigidbody2D.velocity.y);

        /*
		//check out direction and apply force depending on it
		if(left && ( rigidbody2D.velocity.x  > -maxSpeed ))
			rigidbody2D.AddForce(Vector2.right * -1 * speed);
		if(right && ( rigidbody2D.velocity.x  < maxSpeed ))
			rigidbody2D.AddForce(Vector2.right * speed);
        */
 
        /*
		// if you are going to fast, set you to max speed
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
        */
	}


}
