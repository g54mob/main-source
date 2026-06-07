using System;

[Serializable]
public struct FloatRange
{
	public float min;

	public float max;

	public float length => 0f;

	public FloatRange(float min, float max)
	{
		this.min = 0f;
		this.max = 0f;
	}

	public float Random()
	{
		return 0f;
	}

	public float ToRatio(float value)
	{
		return 0f;
	}

	public float FromRatio(float ratio)
	{
		return 0f;
	}

	public float MidPoint()
	{
		return 0f;
	}

	public bool IsWithin(float value, bool inclusive = true)
	{
		return false;
	}

	public float Clamp(float value)
	{
		return 0f;
	}
}
