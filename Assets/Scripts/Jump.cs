using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public Transform landingPosition;
	public float trailResetRate;
	private float AIJumpSpeed;
	public GameObject DebuggingTrail;
    public bool canAchieve = false;
    private GameObject AICharacter;
    private TwoDController AIController;
    private float xSpeed;
    private float maxYVel;

    void Start() {
        AICharacter = GameObject.FindGameObjectWithTag("AI");
        AIController = AICharacter.GetComponent<TwoDController>();
        xSpeed = 0f;
		AIJumpSpeed = AIController.jumpSpeed;
		startTrail();
        maxYVel = AIController.jumpSpeed;
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
        if (canAchieve)
            return xSpeed;
        else
            return 0f;
    }

    void Update() {
        calculateTarget();
    }

    void calculateTarget() {
        float dY = landingPosition.position.y - transform.position.y;
        float sqrtTerm = Mathf.Sqrt((2.0f * Physics2D.gravity.y * dY) + (maxYVel * maxYVel));
        float time = (-maxYVel - sqrtTerm) / Physics2D.gravity.y;

        xSpeed = (landingPosition.position.x - transform.position.x) / time;

        float maxHeight = (maxYVel * maxYVel) / (2.0f * Mathf.Abs(Physics2D.gravity.y));
        Debug.Log(maxHeight);
        if (dY <= maxHeight) canAchieve = true;
        else canAchieve = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == AICharacter) {
            AIController.JumpAI(xSpeed);
        }
    }
}
