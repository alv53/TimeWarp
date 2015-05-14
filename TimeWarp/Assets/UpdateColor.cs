using UnityEngine;
using System.Collections;

public class UpdateColor : MonoBehaviour {
	public GameObject thePlayer;
	private float L;
	public float origL;
	private Vector3 lastPos;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("OVRPlayerController");
		float timeScale = thePlayer.GetComponent<TimeScale> ().getTimeScale();
		// Set color based on scale
		L = origL;
		gameObject.renderer.material.color = getColor (timeScale);
		lastPos = thePlayer.transform.position;
	}

	private float getRed(){
		float R;
		if (L >= 400 && L < 466) {
			R = -3.03f * L + 1412.2f;
		} else if (L >= 466 && L < 532) {
			R = 0;
		} else if (L >= 532 && L < 579) {
			R = 5.52f * L - 2936.4f;
		} else if (L >= 579 && L < 612) {
			R = -3.71f * L + 2399.7f;
		} else if (L >= 612 && L < 694) {
			R = 1.52f * L - 798.2f;
		} else {
			R = 0;
		}
		return R / 255;
	}
	private float getBlue(){
		float B;
		if (L >= 400 && L < 466) {
			B = 255;
		} else if (L >= 466 && L < 532) {
			B = -3.86f * L + 2055.5f;
		} else {
			B = 0;
		}
		return B / 255;
	}

	private float getGreen(){
		float G;
		if (L >= 466 && L < 532) {
			G = 3.86f * L - 1800;
		} else if (L >= 532 && L < 579) {
			G = 255;
		} else if (L >= 579 && L < 694) {
			G = -2.2f * L + 1524.9f;
		} else {
			G = 0;
		}
		return G / 255;
	}

	// Applies the doppler effect to get a new L
	private float applyDoppler(float timeScale){
		GameObject OVRCamera = GameObject.Find ("OVRCameraRig");
		Vector3 playerVelocity = (thePlayer.transform.position - lastPos) / Time.deltaTime;
		lastPos = thePlayer.transform.position;
		Vector3 cameraOrient = OVRCamera.GetComponent<OVRCameraRig> ().centerEyeAnchor.forward;
		Vector3 playerOrient = thePlayer.transform.forward;
		Vector3 totalOrient = cameraOrient + playerOrient;
		totalOrient.Normalize();
		float c = 3 * Mathf.Pow (10, 8);
		L = origL * (c / (c + Vector3.Dot (totalOrient, playerVelocity)/timeScale));
		return L;
	}

	// Function which will use Nate's math to determine the color of the object based on scale of time.
	private Color getColor(float timeScale){
		timeScale = (timeScale == 0) ? 1 : timeScale;
		//Apply doppler effect
		L = applyDoppler (timeScale);

		// Get colors based on wavelength L
		float R, G, B;
		R = getRed ();
		G = getGreen();
		B = getBlue ();


		Color newColor = new Color (R, G, B);

		return newColor;
	}

	// Update is called once per frame
	void Update () {
		float timeScale = thePlayer.GetComponent<TimeScale> ().getTimeScale();
		// Set color based on scale
		gameObject.renderer.material.color = getColor (timeScale);
	}
}
