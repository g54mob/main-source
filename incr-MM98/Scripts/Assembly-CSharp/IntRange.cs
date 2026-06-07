using System;
using UnityEngine;

[Serializable]
public struct IntRange
{
	[SerializeField]
	private int minimum;

	[SerializeField]
	private int maximum;

	public int Minimum => minimum;

	public int Maximum => maximum;

	public int Random => BiteRandom.NextInt(minimum, maximum);

	public int Average => (minimum + maximum) / 2;

	public IntRange(int value)
		: this(value, value)
	{
	}

	public IntRange(int minimum, int maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public int Clamp(int value)
	{
		return Math.Clamp(value, minimum, maximum);
	}

	public int Lerp(float t)
	{
		return Math.Clamp(LerpUnclamped(t), minimum, maximum);
	}

	public int LerpUnclamped(float t)
	{
		return (int)((float)minimum * (1f - t) + (float)maximum * t);
	}
}
