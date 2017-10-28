using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
	public float delayTime;
	SpriteRenderer SR;
	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer>();
		Destroy(gameObject, delayTime);
		Invoke("ChangeAlpha", delayTime - 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChangeAlpha() {
		Color temp = SR.color;
		temp.a = 0.5f;
		SR.color = temp;
	}
}
