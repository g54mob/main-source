using System;

public class ThreadSafeRandom
{
	private static readonly Random _global;

	[ThreadStatic]
	private static Random _local;

	private void InitLocal()
	{
	}

	public int Next()
	{
		return 0;
	}

	public double NextDouble()
	{
		return 0.0;
	}

	public float RandomValue()
	{
		return 0f;
	}

	public float RandomRange(float min, float max)
	{
		return 0f;
	}

	public int RandomRange(int min, int max)
	{
		return 0;
	}

	public int RandomSign()
	{
		return 0;
	}
}
