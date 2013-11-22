using UnityEngine;
using System.Collections;

public class JumpPoint : MonoBehaviour {
    
    // The position of the jump point
    public Vector2 jumpLocation;

    // The position of the landing pad
    public Vector2 landingLocation;

    // The change in position from jump to landing
    // this is calculated from the other values
    public Vector2 deltaPosition;

}
