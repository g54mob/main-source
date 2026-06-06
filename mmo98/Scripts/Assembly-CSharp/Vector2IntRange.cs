using System;
using UnityEngine;

[Serializable]
public struct Vector2IntRange
{
	[SerializeField]
	private Vector2Int minimum;

	[SerializeField]
	private Vector2Int maximum;

	public Vector2Int Minimum => minimum;

	public Vector2Int Maximum => maximum;

	public Vector2Int Random => BiteRandom.NextVector2Int(minimum, maximum);

	public Vector2Int Average => (minimum + maximum) / 2;

	public Vector2IntRange(Vector2Int value)
		: this(value, value)
	{
	}

	public Vector2IntRange(Vector2Int minimum, Vector2Int maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}

	public Vector2Int Clamp(Vector2Int value)
	{
		return value.ClampReturn(minimum, maximum);
	}

	public Vector2Int Lerp(float t)
	{
		return Vector2.Lerp(minimum, maximum, t).ToVector2Int();
	}

	public Vector2Int LerpUnclamped(float t)
	{
		return Vector2.LerpUnclamped(minimum, maximum, t).ToVector2Int();
	}

	public bool InRange(Vector2Int value)
	{
		if (value.x >= minimum.x && value.x <= maximum.x && value.y >= minimum.y)
		{
			return value.y <= maximum.y;
		}
		return false;
	}
}
