using System.Collections.Generic;
using UnityEngine;

public static class ProbUtils
{
	public static float GetRandomWithUpperBias(float lowerBound, float upperBound)
	{
		float luckProb = GlobalFields.Instance.LuckProb;
		float num = upperBound - lowerBound;
		return Random.Range(lowerBound + luckProb * num, upperBound);
	}

	public static float GetRandomWithLowerBias(float lowerBound, float upperBound)
	{
		float luckProb = GlobalFields.Instance.LuckProb;
		float num = upperBound - lowerBound;
		float maxInclusive = upperBound - luckProb * num;
		return Random.Range(lowerBound, maxInclusive);
	}

	public static bool CheckWithLuck(float baseProb)
	{
		float num = baseProb + baseProb * GlobalFields.Instance.LuckProb;
		return Random.Range(0f, 1f) <= num;
	}

	public static bool CheckWithDRNGLuck(float baseProb)
	{
		float num = baseProb + baseProb * GlobalFields.Instance.LuckProb;
		return DRNG.Instance.NextFloat(0f, 1f) <= num;
	}

	public static bool CheckWithReverseLuck(float baseProb)
	{
		float num = baseProb - baseProb * GlobalFields.Instance.LuckProb;
		return Random.Range(0f, 1f) <= num;
	}

	public static List<int> GetRandomNumbersWithoutRepeating(int minNum, int maxNum, int count)
	{
		if (maxNum - minNum + 1 < count)
		{
			Debug.Log("Invalid input for random numbers!");
			return null;
		}
		List<int> list = new List<int>();
		int num = 0;
		while (num < count)
		{
			int item = Random.Range(minNum, maxNum + 1);
			if (!list.Contains(item))
			{
				list.Add(item);
				num++;
			}
		}
		return list;
	}
}
