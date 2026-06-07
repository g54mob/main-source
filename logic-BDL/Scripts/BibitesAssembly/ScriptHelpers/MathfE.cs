using System;
using UnityEngine;

namespace ScriptHelpers
{
	public static class MathfE
	{
		public static float Remap(this float value, float minI, float maxI, float minO, float maxO)
		{
			return Mathf.Lerp(minO, maxO, Mathf.InverseLerp(minI, maxI, value));
		}

		public static float ThresholdRemap(this float value, float threshold, float fixedPoint = 1f)
		{
			return Mathf.Sign(value) * Mathf.Abs(value).Remap(threshold, fixedPoint, 0f, fixedPoint);
		}

		public static float FloorApproximately(this float val)
		{
			float result = Mathf.Round(val);
			float num = Mathf.Floor(val);
			if (!(val - num > 0.999f))
			{
				return num;
			}
			return result;
		}

		public static float RoundToMSD(float val, int precision = 0)
		{
			float num = Mathf.Floor(Mathf.Log10(val)) - (float)precision;
			return Mathf.Round(val * Mathf.Pow(10f, 0f - num)) * Mathf.Pow(10f, num);
		}

		public static float SafeSqrt(float val)
		{
			if (val <= 0f)
			{
				return 0f;
			}
			return Mathf.Sqrt(val);
		}

		public static float SafeDiv(float numerator, float denominator)
		{
			float num = numerator / denominator;
			if (float.IsNaN(num))
			{
				Debug.LogError(new ArithmeticException("Value is NaNs"));
			}
			return num;
		}
	}
}
