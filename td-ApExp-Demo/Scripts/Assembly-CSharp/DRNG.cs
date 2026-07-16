using System;
using UnityEngine;

public class DRNG : MonoBehaviour
{
	protected System.Random random;

	protected int seed;

	protected int nextIntIndex;

	protected int nextFloatIndex;

	protected int nextBoolIndex;

	public static DRNG Instance { get; protected set; }

	public int Seed
	{
		get
		{
			return seed;
		}
		set
		{
			seed = value;
			random = new System.Random(seed);
		}
	}

	public int NextIntIndex => nextIntIndex;

	public int NextFloatIndex => nextFloatIndex;

	public int NextBoolIndex => nextBoolIndex;

	public DRNG(int seed)
	{
		Seed = seed;
	}

	protected void Awake()
	{
		Instance = this;
	}

	public void Init()
	{
		Seed = 0;
	}

	public void ResetWithSeed(int newSeed)
	{
		Debug.LogWarning($"DRNG reset to {newSeed}");
		Seed = newSeed;
		nextIntIndex = 0;
		nextFloatIndex = 0;
		nextBoolIndex = 0;
	}

	public void InitWithSeedAndNextCounts(int seed, int nextIntCount, int nextFloatCount, int nextBoolCount)
	{
		Seed = seed;
	}

	public int NextInt()
	{
		nextIntIndex++;
		return random.Next();
	}

	public int NextInt(int minInclusive, int maxExclusive)
	{
		nextIntIndex++;
		return random.Next(minInclusive, maxExclusive);
	}

	public float NextFloat()
	{
		nextFloatIndex++;
		return (float)random.NextDouble();
	}

	public float NextFloat(float minInclusive, float maxExclusive)
	{
		nextFloatIndex++;
		return minInclusive + (float)random.NextDouble() * (maxExclusive - minInclusive);
	}

	public float NextFloatInclusive(float minInclusive, float maxInclusive)
	{
		nextFloatIndex++;
		return minInclusive + Mathf.Clamp((float)random.NextDouble() * (maxInclusive + 0.001f - minInclusive), minInclusive, maxInclusive);
	}

	public float NextFloat01()
	{
		nextFloatIndex++;
		return Mathf.Clamp01(NextFloat(0f, 1.001f));
	}

	public bool NextBool()
	{
		nextBoolIndex++;
		return random.Next(2) == 0;
	}

	public static int StringToSeed(string seedString)
	{
		int num = 17;
		foreach (char c in seedString)
		{
			num = num * 31 + c;
		}
		return num;
	}
}
