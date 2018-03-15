using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 initialVelocityVector;
	public Vector3 initialPos;
	//public float gravityForce;

	public float a0;
	public float x0;
	public float t = 0.0f;
	public float gravityForce = 9.82f;
	//public float timeStep;
	public float timeStep = 0.001f;
	public float mass = 23323f;
	// public float yv = v;
	public float inputSpeed = 100;

	public float k_x = 0.020f; // Air resitance
	public float k_y = 0.065f; // Air resitance
	public float u_w = -2; // Headwind. 

	Vector2 uvv;

	// Use this for initialization
	void Start () {
		
		// Rigidbody body = new Rigidbody ();
		// gameObject.AddComponent<Rigidbody>();
		// gameObject.GetComponent<Rigidbody> ().useGravity = false;
		// uvv = new Vector2 (Mathf.Sin (a0) * inputSpeed, Mathf.Cos (a0) * inputSpeed);
		// gravityForce = new Vector3 (0f, gravityForce, 0f);

	}


	public void init(float a00, float inputSpeed2) {
		uvv = new Vector2 (Mathf.Sin (Mathf.PI/2-a00) * inputSpeed2, Mathf.Cos (Mathf.PI/2-a00) * inputSpeed2);
	}

	Vector2 pos(float t, Vector2 uvv) {

		return new Vector2 (-k_x * (uvv.x - u_w) * Mathf.Sqrt(Mathf.Pow ((uvv.x - u_w),2) + Mathf.Pow (uvv.y, 2)), -gravityForce - k_y * uvv.y * Mathf.Sqrt (Mathf.Pow ((uvv.x - u_w), 2) + Mathf.Pow (uvv.y, 2) ));

	}
		
	public float y = 1.5f;
	public float x = 0;
	public float t_new = 0;
	public float tt = 0.0f;
	public float h = 0.1f;
	public Vector2 uvv_new;

	// Vector3 zPosition(){

		// float z = initialPos.z + (initialVelocityVector.z*t*Mathf.Cos(a0));
		//Vector3 zPos = new Vector3(0,0,z);
		// return zPos;

	// }

	Vector2 RKstep(float t, Vector2 y, float h){

		Vector2 s1 = h * pos(t, y);
		Vector2 s2 = h * pos(t+h/2, y+s1/2);
		Vector2 s3 = h * pos(t+h/2, y+s2/2);
		Vector2 s4 = h * pos(t+h, y+s3);

		Vector2 y_ut = y + (s1 + 2 * s2 + 2 * s3 + s4) / 6;

		return y_ut;

	}



	float[] trajectoryX = new float[10000000];
	float[] trajectoryY = new float[10000000];

	public void calculateTrajectory(){

		for (int i = 0; i < 1000; i++) {
			
			t_new = t + h;
			uvv_new = RKstep(t, uvv, h); // y new 

			t = t_new;
			uvv = uvv_new;

			if (uvv.x == null || uvv.y == null) {
				break;
			}

			y = y + uvv.y * h;
			x = x + uvv.x * h;

			trajectoryX[i] = x;
			trajectoryY[i] = y;

			if (y < 0){
				
				break;
			}

		}

	}



	float xPosition(){
		float x = initialPos.x + (inputSpeed*tt*Mathf.Sin(x0));
		return x;
	}

	int i = 0;
	// Update is called once per frame
	void Update () {
		//print (y);
		// Ball.
		i++;
		tt = tt + h;
	

		float x1 = transform.position.x + x0*2;

		if (transform.position.y < 0.1) {

			x0 = 0.0f;
			Destroy (this.gameObject);

		}
			
		transform.position = new Vector3 (x1, trajectoryY [i], trajectoryX [i]);

		
	//	transform.position = new Vector3 (x, y, 0);
		

	}
}
