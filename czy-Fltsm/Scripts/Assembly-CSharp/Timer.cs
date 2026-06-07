using System;
using UnityEngine;

[Serializable]
public class Timer
{
	[SerializeField]
	private float _minimumDuration;

	[SerializeField]
	private float _maximumDuration;

	private float _startTime;

	private float _duration;

	public Timer(float minimumDuration, float maximumDuration)
	{
		_minimumDuration = minimumDuration;
		_maximumDuration = maximumDuration;
	}

	public void Reset()
	{
		_startTime = Time.time;
		_duration = UnityEngine.Random.Range(_minimumDuration, _maximumDuration);
	}

	public bool CountDown()
	{
		return Time.time > _startTime + _duration;
	}
}
