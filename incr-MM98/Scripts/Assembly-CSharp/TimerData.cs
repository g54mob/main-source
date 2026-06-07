using Cysharp.Text;
using UnityEngine;

public readonly struct TimerData
{
	public static TimerData Empty;

	public readonly float Current;

	public readonly float Duration;

	public float Normalized
	{
		get
		{
			if (Duration <= 0f)
			{
				return 0f;
			}
			return Current / Duration;
		}
	}

	public bool IsDone => Mathf.Approximately(Current, Duration);

	public bool IsActive
	{
		get
		{
			if (Duration != 0f)
			{
				return !IsDone;
			}
			return false;
		}
	}

	public TimerData(float duration)
		: this(0f, duration)
	{
	}

	public TimerData(float current, float duration)
	{
		Current = current;
		Duration = duration;
	}

	public TimerData Advance(float deltaTime)
	{
		return new TimerData(Mathf.Min(Current + deltaTime, Duration), Duration);
	}

	public override string ToString()
	{
		return ZString.Format("{0:F1}/{1:F1}", Current, Duration);
	}
}
