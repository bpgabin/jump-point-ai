using UnityEngine;
using System.Collections;

public class JumpAlgorithm : MonoBehaviour {

    // Holds the jump point to use
    private JumpPoint jumpPoint;

    // Keeps track of whether the jump is achieveable
    private bool canAchieve = false;

    // Holds the maximum speed of the character
    private float maxSpeed;

    // Holds the maximum vertical jump velocity
    private float maxYVelocity;

    // Retrieve the steering for this jump
    public void GetSteering() {
        // Check if we have a trajectory, and create on if not
        
    }

    public void CalculateTarget() {

    }

    // Private helper method for the CalculateTarget function
    private void CheckJumpTime() {

    }
}
