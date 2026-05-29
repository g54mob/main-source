using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SeededRandom
{
	private static char[] StringCharacters = new char[62]
	{
		'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
		'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
		'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
		'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
		'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
		'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
		'8', '9'
	};

	public static SeededRandom Global = new SeedGenerator().Add(DateTime.Now.Ticks).CreateRandom();

	private ulong State;

	public SeededRandom(ulong seed)
	{
		State = seed;
	}

	public ulong RandomLong()
	{
		ulong num = (State += 11400714819323198485uL);
		long num2 = (long)(num ^ (num >> 30)) * -4658895280553007687L;
		long num3 = (long)((ulong)num2 ^ ((ulong)num2 >> 27)) * -7723592293110705685L;
		return (ulong)num3 ^ ((ulong)num3 >> 31);
	}

	public uint RandomInt()
	{
		return (uint)RandomLong();
	}

	public int RandomRange(int lo, int hi)
	{
		return (int)(RandomInt() % (hi - lo)) + lo;
	}

	public float RandomRange(float lo, float hi)
	{
		return RandomFloat() * (hi - lo) + lo;
	}

	public float RandomFloat()
	{
		int num = 16777216;
		return (float)RandomRange(0, num) / (float)num;
	}

	public float RandomGaussian(float mean, float stdDev)
	{
		float f = 1f - RandomFloat();
		float num = 1f - RandomFloat();
		float num2 = Mathf.Sqrt(-2f * Mathf.Log(f)) * Mathf.Sin(MathF.PI * 2f * num);
		return mean + stdDev * num2;
	}

	public float RandomScatter(float baseVal, float scatter = 0.2f)
	{
		return RandomGaussian(baseVal, baseVal * scatter / 2f);
	}

	public bool RandomBool(float chanceOfTrue = 0.5f)
	{
		return RandomFloat() < chanceOfTrue;
	}

	public string RandomString(int length)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < length; i++)
		{
			stringBuilder.Append(Choose(StringCharacters));
		}
		return stringBuilder.ToString();
	}

	public string RandomItemSeed()
	{
		return RandomString(8);
	}

	public T Choose<T>(IList<T> list)
	{
		if (list == null || list.Count == 0)
		{
			return default(T);
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		return list[RandomRange(0, list.Count)];
	}

	public T ChooseEnum<T>()
	{
		Array values = Enum.GetValues(typeof(T));
		if (values.Length == 0)
		{
			return default(T);
		}
		if (values.Length == 1)
		{
			return (T)values.GetValue(0);
		}
		return (T)values.GetValue(RandomRange(0, values.Length));
	}

	public void Shuffle<T>(IList<T> list)
	{
		for (int num = list.Count - 1; num > 0; num--)
		{
			int index = RandomRange(0, num + 1);
			T value = list[num];
			list[num] = list[index];
			list[index] = value;
		}
	}
}
