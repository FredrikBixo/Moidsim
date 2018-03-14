using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 initialVelocityVector;
	public Vector3 initialPos;
	//public float gravityForce;

	public float a0 = 0.6f;
	public float x0 = 0.6f;
	public float gravityForce = 9.82f;
	//public float timeStep;
	public float timeStep = 0.01f;
	public float t;
	public float mass = 23323f;
	// public float yv = v;
	public float v = 17;
	// Use this for initialization
	void Start () {
		// Rigidbody body = new Rigidbody ();
		gameObject.AddComponent<Rigidbody>();
		gameObject.GetComponent<Rigidbody> ().useGravity = false;

		//gravityForce = new Vector3 (0f, gravityForce, 0f);
	}

	Vector3 zPosition(){
		float z = initialPos.z + (initialVelocityVector.z*t*Mathf.Cos(a0));
		Vector3 zPos = new Vector3(0,0,z);
		return zPos;
	}

	Vector3 xPosition(){
		float x = initialPos.x + (initialVelocityVector.x*t);
		Vector3 xPos = new Vector3(x,0,0);
		// yv = v * Mathf.Sin (a0) - gravityForce * t;
		return xPos;
	}

	Vector3 yPosition(){
		float y = initialPos.y+(initialVelocityVector.z*t*Mathf.Sin(a0)-(0.5f*gravityForce*t*t));
		if (y < 0) {
			y = 0;
		}
		Vector3 yPos = new Vector3(0,y,0);
		// yv = v * Mathf.Sin (a0) - gravityForce * t;


		return yPos;
	}

	// Update is called once per frame
	void Update () {
		t = t + timeStep;

		//  transform.position =
		Vector3 z = zPosition();
		Vector3 y = yPosition();
		Vector3 x = xPosition();
		Vector3 xy = z+y+x;
		transform.position = xy;


		//  transform.position -= gravityForce * Time.deltaTime * 1;

	}
}
