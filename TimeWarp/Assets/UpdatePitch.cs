using UnityEngine;
using System.Collections;

public class UpdatePitch : MonoBehaviour {
	public AudioSource audio;
	public GameObject thePlayer;
	public float origPitch;
	private Vector3 lastPos;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		origPitch = audio.pitch;
		thePlayer = GameObject.Find ("OVRPlayerController");
		lastPos = thePlayer.transform.position;
	}
	private void applyDoppler(float timeScale){
		Vector3 playerVelocity = (thePlayer.transform.position - lastPos)*0.5f / Time.deltaTime;
		lastPos = thePlayer.transform.position;
		Vector3 AudioPos = gameObject.transform.position;
		Vector3 normalVector = AudioPos - lastPos;
		int speedOfSound = 344;
		audio.pitch *= (speedOfSound + Vector3.Dot (normalVector, playerVelocity) / timeScale) / speedOfSound;
	}
	// Update is called once per frame
	void Update () {
		// TODO: Use correct math for pitch. Currently randomly grabs timeIndex and uses that as pitch
		// Will need to update to grab timeScale using getTimeScale() instead, cuz right now this is just putting pitch on a linear scale.
		float timeScale = thePlayer.GetComponent<TimeScale> ().getTimeScale();
		audio.pitch = timeScale;
		if (audio.pitch < 0)
			audio.pitch = 1 / Mathf.Abs (audio.pitch);
		if(timeScale != 1)
			applyDoppler (timeScale);
		if(Input.GetKeyDown("F"))
		{
			if(audio.volume > 0.0f)
				audio.volume -= 0.05f;
		}
		if(Input.GetKeyDown("R"))
		{
			if(audio.volume <= 0.65f)
				audio.volume += 0.05f;
		}
	}
}
