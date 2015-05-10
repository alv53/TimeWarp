using UnityEngine;
using System.Collections;

public class UpdatePitch : MonoBehaviour {
	public AudioSource audio;
	public GameObject thePlayer;
	public float origPitch;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		origPitch = audio.pitch;
		thePlayer = GameObject.Find ("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Use correct math for pitch. Currently randomly grabs timeIndex and uses that as pitch
		// Will need to update to grab timeScale using getTimeScale() instead, cuz right now this is just putting pitch on a linear scale.
		audio.pitch = thePlayer.GetComponent<TimeScale> ().timeIndex;
		if (audio.pitch == 0)
			audio.pitch = 1;
		if (audio.pitch < 0)
			audio.pitch = 1 - Mathf.Abs (audio.pitch) / 10;
		Debug.Log (audio.pitch);
	}
}
