using System;
using UnityEngine;

[Serializable]
public class ThresholdedState
{
	[Tooltip("Threshold for this state. (Will activate for any progress below it.)")]
	[Range(0f, 1f)]
	public float Threshold;

	[Tooltip("State object to show.")]
	public GameObject State;

	public void SetActive(bool value)
	{
		if ((bool)State)
		{
			State.SetActive(value);
		}
	}
}
