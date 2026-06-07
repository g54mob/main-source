using System;
using UnityEngine;

[Serializable]
public struct FloatRange
{
	[SerializeField]
	private float minimum;

	[SerializeField]
	private float maximum;

	public float Minimum => minimum;

	public float Maximum => maximum;

	public float Random => BiteRandom.NextFloat(minimum, maximum);

	public float Average => (minimum + maximum) / 2f;

	public FloatRange(float value)
		: this(value, value)
	{
	}

	public FloatRange(float minimum, float maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public float Clamp(int value)
	{
		return Math.Clamp(value, minimum, maximum);
	}

	public float Lerp(float t)
	{
		return Math.Clamp(LerpUnclamped(t), minimum, maximum);
	}

	public float LerpUnclamped(float t)
	{
		return minimum * (1f - t) + maximum * t;
	}
}
