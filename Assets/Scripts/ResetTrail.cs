using UnityEngine;
using System.Collections;

public class ResetTrail : MonoBehaviour {
	public GameObject jPoint;
	// Use this for initialization
	void Start () {
		jPoint = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("JumpTrail")){
			Debug.Log ("startTrail");
			jPoint.GetComponent<Jump>().startTrail();
			Destroy( other.gameObject );
		}
	}
}
