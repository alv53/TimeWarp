using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour {
	/// <summary>
	/// Index representing time scale ranging from [-9, 9]
	/// </summary>
	public int timeIndex;

	/// <summary>
	/// Represents individual increments
	/// </summary>
	public int timeIncrement;

	private int delay;
	// Use this for initialization
	void Start () {
		timeIndex = 0;
		timeIncrement = 1;
		delay = 0;
	}

	public float getTimeScale(){
		return timeIncrement * Mathf.Pow (10, timeIndex);
	}
	private void increaseIncrement(){
		timeIncrement = (timeIncrement == 10) ? 10 : timeIncrement + 1;
	}
	private void decreaseIncrement(){
		timeIncrement = (timeIncrement == 0) ? 0 : timeIncrement - 1;
	}
	private void increaseTime() {
		if (timeIndex != 0) {
			timeIncrement = 1;
			timeIndex ++;
		}
	}
	private void decreaseTime() {
		if (timeIndex != -9) {
			timeIncrement = 9;
			timeIndex --;
		}

	}

	private void updateTimeScale(){
		if (Input.GetKey (KeyCode.PageUp || KeyCode.UpArrow) && timeIncrement == 9)
			increaseTime ();
		else if (Input.GetKey (KeyCode.PageUp || KeyCode.UpArrow))
			increaseIncrement ();
		if (Input.GetKey (KeyCode.PageDown || KeyCode.DownArrow) && timeIncrement == 1)
			decreaseTime ();
		else if (Input.GetKey (KeyCode.PageDown || KeyCode.DownArrow))
			decreaseIncrement ();
	}

	// Update is called once per frame
	void Update () {
		if (delay == 0) {
			updateTimeScale ();
			delay = 1;
				} else {
			delay = (delay+1)%10;
				}
	}
}
