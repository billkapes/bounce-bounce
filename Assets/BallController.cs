using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour {
	public float speed;
	public float thetimescale;
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
		thetimescale = Time.timeScale;
		if (Input.GetKeyDown(KeyCode.Space) && canInput) {
			ChangeDir();
			//Sequence mySequence = DOTween.Sequence();
			//mySequence.Append( DOTween.To(()=> Time.timeScale, x=> Time.timeScale = x, 0.01f, 0.25f)).OnComplete(ChangeDir);
			//mySequence.Append( DOTween.To(()=> Time.timeScale, x=> Time.timeScale = x, 1f, 0.5f));

		}
	}

	void ChangeDir() {
		if (myRb.velocity.y > 0f) {
			DOTween.To(() => myRb.velocity, x=> myRb.velocity = x, new Vector2 (0f, -speed), 1);
		} else {
			DOTween.To(() => myRb.velocity, x=> myRb.velocity = x, new Vector2 (0f, speed), 1);
		}
		//myRb.velocity = new Vector3 (0f, myRb.velocity.y * -1f);
		//DOTween.To(()=> Time.timeScale, x=> Time.timeScale = x, 1f, 0.5f);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "PaddleTop") {
			myRb.velocity = Vector3.up * -speed;
			speed += 0.1f;
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
