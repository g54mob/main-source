using System;

[Serializable]
public struct IntRange
{
	public int min;

	public int max;

	public int length => 0;

	public IntRange(int min, int max)
	{
		this.min = 0;
		this.max = 0;
	}

	public int Random()
	{
		return 0;
	}

	public bool IsWithin(int value, bool inclusive = true)
	{
		return false;
	}

	public int Clamp(int value)
	{
		return 0;
	}
}
