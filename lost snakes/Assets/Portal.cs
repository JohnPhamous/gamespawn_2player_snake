using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D snake) {
		// Debug.Log("collided with portal");
		if (snake.gameObject.tag == "Player2") {
			Debug.Log("Player 1 won");
			SceneManager.LoadScene("End", LoadSceneMode.Single);
		}
		if (snake.gameObject.tag == "Player") {
			Debug.Log("Player 2 won");
			SceneManager.LoadScene("End2", LoadSceneMode.Single);
		}
	}
}
