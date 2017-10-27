using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	public float speed;

	Rigidbody2D myRb;

	void Awake() {
		myRb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		myRb.velocity = Vector3.up * speed; 	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			myRb.velocity = new Vector3 (0f, myRb.velocity.y * -1f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PaddleTop") {
			myRb.velocity = Vector3.up * -speed;
		} else if (other.tag == "PaddleBottom") {
			myRb.velocity = Vector3.up * speed;
		}
	}
}
