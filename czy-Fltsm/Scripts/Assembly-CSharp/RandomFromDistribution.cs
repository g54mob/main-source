using System;
using System.Collections.Generic;
using UnityEngine;

public static class RandomFromDistribution
{
	public enum ConfidenceLevel_e
	{
		_60 = 0,
		_80 = 1,
		_90 = 2,
		_95 = 3,
		_98 = 4,
		_99 = 5,
		_998 = 6,
		_999 = 7
	}

	public enum Direction_e
	{
		Right = 0,
		Left = 1
	}

	private static float[] confidence_to_z_score = new float[8] { 0.8416212f, 1.2815516f, 1.6448536f, 1.959964f, 2.3263478f, 2.5758293f, 3.0902324f, 3.2905266f };

	public static float RandomRangeNormalDistribution(float min, float max, ConfidenceLevel_e confidence_level_cutoff)
	{
		float mean = 0.5f * (min + max);
		float num = confidence_to_z_score[(int)confidence_level_cutoff];
		float std_dev = (max - min) / 2f / num;
		float num2;
		do
		{
			num2 = RandomNormalDistribution(mean, std_dev);
		}
		while (num2 > max || num2 < min);
		return num2;
	}

	public static float RandomNormalDistribution(float mean, float std_dev)
	{
		return RandomFromStandardNormalDistribution() * std_dev + mean;
	}

	public static float RandomFromStandardNormalDistribution()
	{
		float num;
		float num2;
		float num3;
		do
		{
			num = UnityEngine.Random.Range(-1f, 1f);
			num2 = UnityEngine.Random.Range(-1f, 1f);
			num3 = num * num + num2 * num2;
		}
		while (num3 == 0f || !(num3 < 1f));
		float num4 = ((UnityEngine.Random.Range(0, 2) != 0) ? num2 : num);
		return num4 * Mathf.Sqrt(-2f * Mathf.Log(num3) / num3);
	}

	public static float RandomRangeSlope(float min, float max, float skew, Direction_e direction)
	{
		return min + RandomFromSlopedDistribution(skew, direction) * (max - min);
	}

	public static float RandomFromSlopedDistribution(float skew, Direction_e direction)
	{
		float num = Inverse_Sec_Sqrd(skew);
		float maxInclusive = Sec_Sqrd_CumulativeDistributionFunction(num);
		float num2 = Sec_Sqrd_InverseCumulativeDistributionFunction(UnityEngine.Random.Range(0f, maxInclusive)) / num;
		if (direction == Direction_e.Left)
		{
			num2 = 1f - num2;
		}
		return num2;
	}

	private static float Inverse_Sec_Sqrd(float y)
	{
		return Mathf.Acos(1f / Mathf.Sqrt(y));
	}

	private static float Sec_Sqrd_CumulativeDistributionFunction(float x)
	{
		return Mathf.Tan(x);
	}

	private static float Sec_Sqrd_InverseCumulativeDistributionFunction(float x)
	{
		return Mathf.Atan(x);
	}

	public static float RandomRangeLinear(float min, float max, float slope)
	{
		float num = RandomLinear(slope);
		return min + (max - min) * num;
	}

	public static float RandomLinear(float slope)
	{
		float num = RandomFromLinearWithPositiveSlope(Mathf.Abs(slope));
		if (slope < 0f)
		{
			return 1f - num;
		}
		return num;
	}

	private static float RandomFromLinearWithPositiveSlope(float slope)
	{
		if (slope == 0f)
		{
			return UnityEngine.Random.Range(0f, 1f);
		}
		float num;
		float num2;
		do
		{
			num = UnityEngine.Random.Range(0f, 1f);
			num2 = UnityEngine.Random.Range(0f, 1f);
			if (slope < 1f)
			{
				num2 -= (1f - slope) / 2f;
			}
		}
		while (num2 > num * slope);
		return num;
	}

	public static float RandomRangeExponential(float min, float max, float exponent, Direction_e direction)
	{
		return min + RandomFromExponentialDistribution(exponent, direction) * (max - min);
	}

	public static float RandomFromExponentialDistribution(float exponent, Direction_e direction)
	{
		float maxInclusive = ExponentialRightCDF(1f, exponent);
		float num = EponentialRightInverseCDF(UnityEngine.Random.Range(0f, maxInclusive), exponent);
		if (direction == Direction_e.Left)
		{
			num = 1f - num;
		}
		return num;
	}

	private static float ExponentialRightInverse(float y, float exponent)
	{
		return Mathf.Pow(y, 1f / exponent);
	}

	private static float ExponentialRightCDF(float x, float exponent)
	{
		float num = exponent + 1f;
		return Mathf.Pow(x, num) / num;
	}

	private static float EponentialRightInverseCDF(float x, float exponent)
	{
		float num = exponent + 1f;
		return Mathf.Pow(num * x, 1f / num);
	}

	public static int RandomChoiceFollowingDistribution(List<float> probabilities)
	{
		float[] array = new float[probabilities.Count];
		float num = 0f;
		for (int i = 0; i < probabilities.Count; i++)
		{
			array[i] = num + probabilities[i];
			num = array[i];
		}
		float value = UnityEngine.Random.Range(0f, array[probabilities.Count - 1]);
		int num2 = Array.BinarySearch(array, value);
		if (num2 < 0)
		{
			num2 = ~num2;
		}
		return num2;
	}
}
