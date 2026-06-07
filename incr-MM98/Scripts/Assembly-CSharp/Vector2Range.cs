using System;
using UnityEngine;

[Serializable]
public struct Vector2Range
{
	[SerializeField]
	private Vector2 minimum;

	[SerializeField]
	private Vector2 maximum;

	public Vector2 Minimum => minimum;

	public Vector2 Maximum => maximum;

	public Vector2 Random => BiteRandom.NextVector2(minimum, maximum);

	public Vector2 Average => (minimum + maximum) / 2f;

	public Vector2Range(Vector2 value)
		: this(value, value)
	{
	}

	public Vector2Range(Vector2 minimum, Vector2 maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public Vector2 Clamp(Vector2 value)
	{
		return value.Clamp(minimum, maximum);
	}

	public Vector2 Lerp(float t)
	{
		return Vector2.Lerp(minimum, maximum, t);
	}

	public Vector2 LerpUnclamped(float t)
	{
		return Vector2.LerpUnclamped(minimum, maximum, t);
	}

	public bool InRange(Vector2 value)
	{
		if (value.x >= minimum.x && value.x <= maximum.x && value.y >= minimum.y)
		{
			return value.y <= maximum.y;
		}
		return false;
	}
}
