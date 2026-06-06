using System;
using UnityEngine;

[Serializable]
public struct LongRange
{
	[SerializeField]
	private long minimum;

	[SerializeField]
	private long maximum;

	public long Minimum => minimum;

	public long Maximum => maximum;

	public long Random => BiteRandom.NextLong(minimum, maximum);

	public long Average => (minimum + maximum) / 2;

	public LongRange(long value)
		: this(value, value)
	{
	}

	public LongRange(long minimum, long maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public long Clamp(long value)
	{
		return Math.Clamp(value, minimum, maximum);
	}

	public long Lerp(float t)
	{
		return Math.Clamp(LerpUnclamped(t), minimum, maximum);
	}

	public long LerpUnclamped(float t)
	{
		return (long)((double)minimum * (1.0 - (double)t) + (double)((float)maximum * t));
	}
}
