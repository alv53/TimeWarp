using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Update_Fade : MonoBehaviour {

	public GameObject thePlayer;
	public Image the_image;
	private Color c;
	private float L;
	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("OVRPlayerController");
		c = the_image.color;
		L = thePlayer.GetComponent<TimeScale>().getTimeScale();
		c.a = 0.0f;
		the_image.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		L = thePlayer.GetComponent<TimeScale>().getTimeScale();
		if (L < 1.0f) 
		{
			c.a = 0.03f *(-Mathf.Log (L));
			the_image.color = c;
		}
		else 
		{
			c.a = 0.0f;
			the_image.color = c;
		}
	}
}
