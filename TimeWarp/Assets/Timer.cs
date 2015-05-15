using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public GameObject thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<TextMesh>.text 
		//TextMesh.text = "Time Scale: " + thePlayer.GetComponent<TimeScale>().getTimeScale();
	}
}
