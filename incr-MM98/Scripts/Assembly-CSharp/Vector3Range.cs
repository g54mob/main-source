using System;
using UnityEngine;

[Serializable]
public struct Vector3Range
{
	[SerializeField]
	private Vector3 minimum;

	[SerializeField]
	private Vector3 maximum;

	public Vector3 Minimum => minimum;

	public Vector3 Maximum => maximum;

	public Vector3 Random => BiteRandom.NextVector3(minimum, maximum);

	public Vector3 Average => (minimum + maximum) / 2f;

	public Vector3Range(Vector3 value)
		: this(value, value)
	{
	}

	public Vector3Range(Vector3 minimum, Vector3 maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public Vector3 Clamp(Vector3 value)
	{
		return value.Clamp(minimum, maximum);
	}

	public Vector3 Lerp(float t)
	{
		return Vector3.Lerp(minimum, maximum, t);
	}

	public Vector3 LerpUnclamped(float t)
	{
		return Vector3.LerpUnclamped(minimum, maximum, t);
	}

	public bool InRange(Vector3 value)
	{
		if (value.x >= minimum.x && value.x <= maximum.x && value.y >= minimum.y && value.y <= maximum.y && value.z >= minimum.z)
		{
			return value.z <= maximum.z;
		}
		return false;
	}
}
