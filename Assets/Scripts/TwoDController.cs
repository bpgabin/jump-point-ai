using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TwoDController : MonoBehaviour {
	public float speed, maxSpeed;
    public float jumpSpeed;

    public List<Jump> jumpList;

	private Transform groundCheck;
	private bool left, grounded, jump;
    private bool right = true;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 12) {
            grounded = true;
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Jump", false);
        }
    }

	void Awake(){
		groundCheck = transform.Find("GroundCheck");
	}
	// Use this for initialization
	void Start () {
        jumpList = new List<Jump>();
        GameObject[] jumpObjects = GameObject.FindGameObjectsWithTag("JumpPoint");
        for(int j = 0; j < jumpObjects.Length; j++) {
            if (jumpList.Count == 0) jumpList.Add(jumpObjects[j].GetComponent<Jump>());
            else {
                bool added = false;
                for (int i = 0; i < jumpList.Count; i++) {
                    if (jumpObjects[j].transform.position.x < jumpList[i].transform.position.x) {
                        jumpList.Insert(i, jumpObjects[j].GetComponent<Jump>());
                        added = true;
                        break;
                    }
                }
                if (!added) {
                    jumpList.Add(jumpObjects[j].GetComponent<Jump>());
                }
            }
        }
	}

    public void JumpAI(float xSpeed) {
        grounded = false;
        rigidbody2D.velocity = new Vector2(xSpeed, jumpSpeed);
        jumpList.RemoveAt(0);

        Animator anim = GetComponent<Animator>();
        anim.SetBool("Jump", true);
    }

	// Update is called once per frame
	void Update () {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("Speed", rigidbody2D.velocity.x);
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
        if (jumpList.Count > 0 && grounded) {
            if (jumpList[0].canAchieve) {
                float xSpeed = jumpList[0].GetSpeed();
                rigidbody2D.velocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
            }
            else
                rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
        }

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
