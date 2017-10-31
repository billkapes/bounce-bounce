using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] obs;
	public GameObject coin, coinMove;
	public float yMax, randomAmount, xSepMin, xSepMax, speed;
	public Transform spawnPoint;

	float counter = 1f, coinCounter = 3f;
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		maxSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		counter -= Time.deltaTime;
		coinCounter -= Time.deltaTime;
		if (counter < 0f) {
			Spawn();
			counter = Random.Range(randomAmount / 2, randomAmount);
		}

		if (coinCounter <= 0f) {
			float yPos = Random.Range(-yMax + 1f, yMax - 1f);
			if (Random.Range(0, 2) == 0) {
				Instantiate(coin, new Vector3(0f, yPos + 0.5f), Quaternion.identity);
				
			}
			if (Random.Range(0, 2) == 0) {
				Instantiate(coin, new Vector3(0f, yPos), Quaternion.identity);
				
			}
			if (Random.Range(0, 2) == 0) {
				Instantiate(coin, new Vector3(0f, yPos - 0.5f), Quaternion.identity);
				
			}
			coinCounter = 3f;
		}
	}

	void Spawn() {
		float Ypos = Random.Range(-yMax, yMax);
		float Xsep = Random.Range(xSepMin, xSepMax);
		float xSign = 1f;
		float xSpeed = Random.Range(1.5f, maxSpeed);
		if (Random.Range(0, 2) == 0) {
			xSign = -1f;
		}
		int obLength = Random.Range(1, 5);
		for (int i = 0; i < obLength; i++) {
			GameObject obsObj = Instantiate(obs[0], new Vector3( spawnPoint.position.x * xSign - Xsep * xSign * i, Ypos), spawnPoint.rotation) as GameObject;
			obsObj.GetComponent<BasicMove>().speed = xSpeed;
			if (i != obLength - 1) {
				GameObject coinObj =  Instantiate(coinMove, new Vector3( spawnPoint.position.x * xSign - Xsep * xSign * i - Xsep / 2 * xSign, Ypos), spawnPoint.rotation);
				coinObj.GetComponent<BasicMove>().speed = xSpeed;
			}
		}
		//Instantiate(obs[0], new Vector3( spawnPoint.position.x * xSign, Ypos), spawnPoint.rotation);
		//Instantiate(obs[0], new Vector3( spawnPoint.position.x * xSign - Xsep * xSign, Ypos), spawnPoint.rotation);
		//Instantiate(obs[0], new Vector3( spawnPoint.position.x * xSign - Xsep * 2f * xSign, Ypos), spawnPoint.rotation);
		randomAmount -= 0.2f;
		if (randomAmount <= 1f) {
			randomAmount = 1f;
		}

		maxSpeed += 0.1f;
	}
}
