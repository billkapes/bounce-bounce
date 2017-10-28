using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {
	public float speed;

	Rigidbody2D myRB;
	int direction;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();	
		if (transform.position.x > 1f) {
			direction = -1;
		} else {
			direction = 1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		myRB.velocity = new Vector3(direction * speed, 0f);
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
