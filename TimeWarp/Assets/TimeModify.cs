using UnityEngine;
using System.Collections;

public class TimeModify : MonoBehaviour {

	public GameObject thePlayer;

	// Use this for initialization
	void Start() 
	{
		thePlayer = GameObject.Find ("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		float L = thePlayer.GetComponent<TimeScale> ().getTimeScale();
		gameObject.particleSystem.playbackSpeed = L;
	}
}
