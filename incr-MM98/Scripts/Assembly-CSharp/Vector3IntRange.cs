using System;
using UnityEngine;

[Serializable]
public struct Vector3IntRange
{
	[SerializeField]
	private Vector3Int minimum;

	[SerializeField]
	private Vector3Int maximum;

	public Vector3Int Minimum => minimum;

	public Vector3Int Maximum => maximum;

	public Vector3Int Random => BiteRandom.NextVector3Int(minimum, maximum);

	public Vector3Int Average => (minimum + maximum) / 2;

	public Vector3IntRange(Vector3Int value)
		: this(value, value)
	{
	}

	public Vector3IntRange(Vector3Int minimum, Vector3Int maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public Vector3Int Clamp(Vector3Int value)
	{
		return value.ClampReturn(minimum, maximum);
	}

	public Vector3Int Lerp(float t)
	{
		return Vector3.Lerp(minimum, maximum, t).ToVector3Int();
	}

	public Vector3Int LerpUnclamped(float t)
	{
		return Vector3.LerpUnclamped(minimum, maximum, t).ToVector3Int();
	}

	public bool InRange(Vector3Int value)
	{
		if (value.x >= minimum.x && value.x <= maximum.x && value.y >= minimum.y && value.y <= maximum.y && value.z >= minimum.z)
		{
			return value.z <= maximum.z;
		}
		return false;
	}
}
