using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			


			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

			// Add euler angles
			print (transform.position);
			sphere.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+3);
			sphere.AddComponent<Ball>(); 
			sphere.AddComponent<SphereCollider> ();
			sphere.GetComponent<Ball>().initialVelocityVector = transform.up*50;
			sphere.GetComponent<Ball> ().initialPos = transform.position;
			sphere.GetComponent<Ball> ().a0 = Mathf.Atan2 (transform.up.y, transform.up.z); 
			sphere.GetComponent<Ball> ().x0 = Mathf.Atan2 (transform.up.x, transform.up.z); 
			//Instantiate(sphere);

		}
			
	}
}
