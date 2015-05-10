using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUI : MonoBehaviour {
	public Text UIText;
	public GameObject thePlayer;
	// Use this for initialization
	void Start () {
		UIText = GetComponent<Text> ();
		thePlayer = GameObject.Find ("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		UIText.text = "Time Scale: " + thePlayer.GetComponent<TimeScale>().getTimeScale();
	}
}
