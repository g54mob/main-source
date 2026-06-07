using System;

public class RepeatableRandom : Random
{
	private const int MBIG = int.MaxValue;

	private const int MSEED = 161803398;

	private int inext;

	private int inextp;

	private int[] SeedArray = new int[56];

	public static Random SeededInstance(int seed)
	{
		return new RepeatableRandom(seed);
	}

	public RepeatableRandom()
		: this(Environment.TickCount)
	{
	}

	public RepeatableRandom(int Seed)
	{
		int num = ((Seed != int.MinValue) ? (161803398 - Math.Abs(Seed)) : (161803398 - Math.Abs(-2147483647)));
		SeedArray[55] = num;
		int num2 = 1;
		for (int i = 1; i < 55; i++)
		{
			int num3 = 21 * i % 55;
			SeedArray[num3] = num2;
			num2 = num - num2;
			if (num2 < 0)
			{
				num2 += int.MaxValue;
			}
			num = SeedArray[num3];
		}
		for (int j = 1; j < 5; j++)
		{
			for (int k = 1; k < 56; k++)
			{
				SeedArray[k] -= SeedArray[1 + (k + 30) % 55];
				if (SeedArray[k] < 0)
				{
					SeedArray[k] += int.MaxValue;
				}
			}
		}
		inext = 0;
		inextp = 31;
	}

	protected override double Sample()
	{
		if (++inext >= 56)
		{
			inext = 1;
		}
		if (++inextp >= 56)
		{
			inextp = 1;
		}
		int num = SeedArray[inext] - SeedArray[inextp];
		if (num < 0)
		{
			num += int.MaxValue;
		}
		SeedArray[inext] = num;
		return (double)num * 4.656612875245797E-10;
	}

	public override int Next()
	{
		return (int)(Sample() * 2147483647.0);
	}

	public override int Next(int maxValue)
	{
		if (maxValue < 0)
		{
			throw new ArgumentOutOfRangeException("minvalue");
		}
		return (int)(Sample() * (double)maxValue);
	}

	public override int Next(int minValue, int maxValue)
	{
		if (minValue > maxValue)
		{
			throw new ArgumentOutOfRangeException("maxvalue");
		}
		uint num = (uint)(maxValue - minValue);
		if (num <= 1)
		{
			return minValue;
		}
		return (int)((uint)(Sample() * (double)num) + minValue);
	}

	public override void NextBytes(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		for (int i = 0; i < buffer.Length; i++)
		{
			buffer[i] = (byte)(Sample() * 256.0);
		}
	}

	public override double NextDouble()
	{
		return Sample();
	}
}
