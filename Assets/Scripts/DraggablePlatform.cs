using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DraggablePlatform : MonoBehaviour {

	private Transform max, min;
	private LineRenderer line;
	// Use this for initialization
	void Start () {
//		Transform[] children =  transform.GetComponentsInChildren<Transform>();
//		foreach(Transform child in children){
//			if( child.gameObject.name.Equals("Top")){
//				max = child;
//			}else{
//				min = child;
//			}
//		}

		max = transform.parent.gameObject.transform.Find("Top").transform;
		min = transform.parent.gameObject.transform.Find("Bottom").transform;
		line = transform.GetComponentInChildren<LineRenderer>();
		line.SetPosition(0, max.position);
		line.SetPosition(1, min.position);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDrag(){
		Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
		if(-Camera.main.ScreenToWorldPoint(vector).y <= max.position.y && -Camera.main.ScreenToWorldPoint(vector).y >= min.position.y)
			transform.position = new Vector3(transform.position.x, -Camera.main.ScreenToWorldPoint(vector).y, transform.position.z);
	}
}
