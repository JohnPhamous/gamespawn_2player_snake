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

	public int counter = 1;
	private int max_food = 4;
	private int food_spawn_time = 1;
	private float food_start_delay_time = 0.1f;
	// Use this for initialization
	public void Start () {
		counter = 0;
		// Debug.Log("Called start");
		InvokeRepeating("Spawn", food_start_delay_time, food_spawn_time);
	}
	public void Spawn() {
		if (counter <= max_food) {
			counter++;
			int x = (int)Random.Range(border_left.position.x + 2, border_right.position.x - 2);
			int y = (int)Random.Range(border_bottom.position.y + 2, border_top.position.y - 2);
			Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
		}
		// else {
		// 	Debug.Log("Too much food");
		// }
		// Debug.Log("Inside SpawnFood: " + counter);
	}
}
