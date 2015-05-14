using UnityEngine;
using System.Collections;

public class UpdateSpeed : MonoBehaviour {
	public GameObject thePlayer;
	public Vector3 origSpeed = new Vector3 (0, -10, 0);
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("OVRPlayerController");
		gameObject.rigidbody.velocity = origSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		float timeScale = thePlayer.GetComponent<TimeScale> ().getTimeScale();
		gameObject.rigidbody.velocity = new Vector3 (origSpeed.x * timeScale, origSpeed.y * timeScale, origSpeed.z * timeScale);
	}
}
