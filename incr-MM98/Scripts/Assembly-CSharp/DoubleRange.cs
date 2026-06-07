using System;
using UnityEngine;

[Serializable]
public struct DoubleRange
{
	[SerializeField]
	private double minimum;

	[SerializeField]
	private double maximum;

	public double Minimum => minimum;

	public double Maximum => maximum;

	public double Random => BiteRandom.NextDouble(minimum, maximum);

	public double Average => (minimum + maximum) / 2.0;

	public DoubleRange(double value)
		: this(value, value)
	{
	}

	public DoubleRange(double minimum, double maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public double Clamp(double value)
	{
		return Math.Clamp(value, minimum, maximum);
	}

	public double Lerp(float t)
	{
		return Math.Clamp(LerpUnclamped(t), minimum, maximum);
	}

	public double LerpUnclamped(float t)
	{
		return minimum * (1.0 - (double)t) + maximum * (double)t;
	}
}
