using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public Transform landingPosition;
	public float trailResetRate;

    private GameObject AICharacter;
    private TwoDController AIController;
    private float xSpeed;
	private float AIJumpSpeed;
	public GameObject DebuggingTrail;

    void Start() {
        AICharacter = GameObject.FindGameObjectWithTag("AI");
        AIController = AICharacter.GetComponent<TwoDController>();
        xSpeed = 0f;
		AIJumpSpeed = AIController.jumpSpeed;
		startTrail();
    }

	public void startTrail(){
		/*DebuggingTrail.GetComponent<TrailRenderer>().time = 0f;
		DebuggingTrail.transform.position = this.transform.position;
		DebuggingTrail.GetComponent<TrailRenderer>().time = 2;
		DebuggingTrail.rigidbody2D.gravityScale = 1f;
		DebuggingTrail.GetComponent<SpriteRenderer>().enabled = true;*/

		calculateTarget();
		GameObject debugTrailClone = (GameObject)Instantiate( DebuggingTrail );
		debugTrailClone.transform.position = this.transform.position;
		calculateTarget();
		debugTrailClone.rigidbody2D.velocity = new Vector2(xSpeed,AIJumpSpeed);


	}

	/*public void endTrail(){
		DebuggingTrail.rigidbody2D.velocity = Vector3.zero;
		DebuggingTrail.rigidbody2D.gravityScale = 0f;
		DebuggingTrail.GetComponent<SpriteRenderer>().enabled = false;
		Invoke ("startTrail", trailResetRate);
	}*/



    public float GetSpeed() {
        return 5f;
    }

    void Update() {
        calculateTarget();
    }

    void calculateTarget() {
        float dY = landingPosition.position.y - transform.position.y;

        float sqrtTerm = Mathf.Sqrt((2.0f * Physics2D.gravity.y * dY) + (AIController.jumpSpeed * AIController.jumpSpeed));
        float time = (-AIController.jumpSpeed - sqrtTerm) / Physics2D.gravity.y;
        //Debug.Log("time: " + time);


        xSpeed = (landingPosition.position.x - transform.position.x) / time;
        //Debug.Log("xSpeed: " + xSpeed);
    }

    bool checkJumpTime(float time) {
        float vx = (landingPosition.position.x - transform.position.x) / time;
        float speedSq = vx * vx;
        return false;
    }

    void OnTriggerEnter2D(Collider2D other) {
     //   Debug.Log("entered");
        if (other.gameObject == AICharacter) {
            AIController.jumping = true;
            AIController.JumpAI(xSpeed);
            AIController.jumpThing = null;
        }
    }
}
