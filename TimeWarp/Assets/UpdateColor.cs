using UnityEngine;
using System.Collections;

public class UpdateColor : MonoBehaviour {
	public GameObject thePlayer;
	public Color origColor;
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("OVRPlayerController");
		Color origColor = gameObject.renderer.material.color;
	}

	// Function which will use Nate's math to determine the color of the object based on scale of time.
	private Color getColor(float timeScale){
		Color newColor = origColor;
		//TODO: put math here and change newColor
		//Temporary random colors to test, currently changes red to max value when timeScale = 1e9
		newColor += new Color (timeScale / Mathf.Pow (10, 9), 0, 0);
		return newColor;
	}

	// Update is called once per frame
	void Update () {
		float timeScale = thePlayer.GetComponent<TimeScale> ().getTimeScale();
		// Set color based on scale
		gameObject.renderer.material.color = getColor (timeScale);
	}
}
