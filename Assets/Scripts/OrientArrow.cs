using UnityEngine;
using System.Collections;

public class OrientArrow : MonoBehaviour {
	private Sprite arrow;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 formatVec3 = (Vector3)this.transform.rigidbody2D.velocity.normalized;
		formatVec3.x = 0f;
		formatVec3.y = 0f;
		this.transform.Rotate( formatVec3 );
		*/
		this.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2 (this.rigidbody2D.velocity.y, this.rigidbody2D.velocity.x) *  Mathf.Rad2Deg);
	}
}
