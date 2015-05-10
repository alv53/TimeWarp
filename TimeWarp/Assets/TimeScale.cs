using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour {
	/// <summary>
	/// Index representing time scale ranging from [-9, 9]
	/// </summary>
	public int timeIndex;
	// Use this for initialization
	void Start () {
		timeIndex = 0;
	}

	public float getTimeScale(){
		return Mathf.Pow (10, timeIndex);
	}
	private void increaseTime() {
		timeIndex = (timeIndex == 9) ? 9 : timeIndex + 1;
	}
	private void decreaseTime() {
		timeIndex = (timeIndex == -9) ? -9 : timeIndex - 1;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
			increaseTime ();
		if (Input.GetKeyDown (KeyCode.F))
			decreaseTime ();
	}
}
