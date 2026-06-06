using System;
using UnityEngine;

[Serializable]
public struct Vector4Range
{
	[SerializeField]
	private Vector4 minimum;

	[SerializeField]
	private Vector4 maximum;

	public Vector4 Minimum => minimum;

	public Vector4 Maximum => maximum;

	public Vector4 Random => BiteRandom.NextVector4(minimum, maximum);

	public Vector4 Average => (minimum + maximum) / 2f;

	public Vector4Range(Vector4 value)
		: this(value, value)
	{
	}

	public Vector4Range(Vector4 minimum, Vector4 maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public Vector4 Clamp(Vector4 value)
	{
		return value.Clamp(minimum, maximum);
	}

	public Vector4 Lerp(float t)
	{
		return Vector4.Lerp(minimum, maximum, t);
	}

	public Vector4 LerpUnclamped(float t)
	{
		return Vector4.LerpUnclamped(minimum, maximum, t);
	}

	public bool InRange(Vector4 value)
	{
		if (value.x >= minimum.x && value.x <= maximum.x && value.y >= minimum.y && value.y <= maximum.y && value.z >= minimum.z && value.z <= maximum.z && value.w >= minimum.w)
		{
			return value.w <= maximum.w;
		}
		return false;
	}
}
