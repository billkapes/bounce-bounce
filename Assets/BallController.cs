using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	public float speed;

	Rigidbody2D myRb;
	bool canInput;

	void Awake() {
		myRb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		myRb.velocity = Vector3.up * speed; 	
		canInput = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && canInput) {
			myRb.velocity = new Vector3 (0f, myRb.velocity.y * -1f);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "PaddleTop") {
			myRb.velocity = Vector3.up * -speed;
		} else if (other.gameObject.tag == "PaddleBottom") {
			myRb.velocity = Vector3.up * speed;
		} 
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "PaddleBottom" || other.tag == "PaddleTop") {
			canInput = false;
		} else if (other.gameObject.tag == "Coin") {
			Destroy(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "PaddleBottom" || other.tag == "PaddleTop") {
			canInput = true;
		}

	}
}
