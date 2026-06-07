using System;
using UnityEngine;

[Serializable]
public class DoubleClickDetector
{
	public float MinimumTimeToClick = 0.05f;

	public float MaximumTimeToClick = 0.6f;

	private float _minimumTimeThreshold;

	private float _maximumTimeThreshold;

	public bool IsDoubleClick()
	{
		if (Time.time >= _minimumTimeThreshold && Time.time <= _maximumTimeThreshold)
		{
			_minimumTimeThreshold = 0f;
			_maximumTimeThreshold = 0f;
			return true;
		}
		_minimumTimeThreshold = Time.time + MinimumTimeToClick;
		_maximumTimeThreshold = Time.time + MaximumTimeToClick;
		return false;
	}
}
