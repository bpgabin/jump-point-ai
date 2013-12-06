using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public Transform landingPosition;
    private GameObject AICharacter;
    private TwoDController AIController;
    private float xSpeed;

    void Start() {
        AICharacter = GameObject.FindGameObjectWithTag("AI");
        AIController = AICharacter.GetComponent<TwoDController>();
        xSpeed = 0f;
    }

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

        xSpeed = (landingPosition.position.x - transform.position.x) / time;
    }

    bool checkJumpTime(float time) {
        float vx = (landingPosition.position.x - transform.position.x) / time;
        float speedSq = vx * vx;
        return false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == AICharacter) {
            AIController.JumpAI(xSpeed);
        }
    }
}
