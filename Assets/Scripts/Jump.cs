using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public Transform landingPosition;
    public bool canAchieve = false;
    private GameObject AICharacter;
    private TwoDController AIController;
    private float xSpeed;
    private float maxYVel;

    void Start() {
        AICharacter = GameObject.FindGameObjectWithTag("AI");
        AIController = AICharacter.GetComponent<TwoDController>();
        xSpeed = 0f;
        maxYVel = AIController.jumpSpeed;
    }

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
