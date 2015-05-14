using UnityEngine;
using System.Collections;
using System;

public class FallingCapsule : MonoBehaviour {
	// Use this for initialization
	public static System.Random rand;
	void Start () {
		gameObject.renderer.material.color = new Color (0, 0, 1);
		rand = new System.Random();
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < 1) {
			gameObject.transform.position = new Vector3 (rand.Next (0, 20), rand.Next(20,40), rand.Next (0,20));
		}
	}
}
