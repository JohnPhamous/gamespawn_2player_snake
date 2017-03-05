using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
	// Food Prefab
	public GameObject foodPrefab;

	// Border locations
	public Transform border_top;
	public Transform border_bottom;
	public Transform border_left;
	public Transform border_right;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 3, 4);
	}
	void Spawn() {
		int x = (int)Random.Range(border_left.position.x + 2, border_right.position.x - 2);
		int y = (int)Random.Range(border_bottom.position.y - 2, border_top.position.y + 2);

		Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
	}
}
