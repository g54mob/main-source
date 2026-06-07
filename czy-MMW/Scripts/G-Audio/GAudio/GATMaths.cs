using System;
using UnityEngine;

namespace GAudio
{
	public static class GATMaths
	{
		public const double SQRT2 = 1.414213562373095;

		public static void GetMaxAndMin(float[] data, int fromIndex, int length, out float min, out float max)
		{
			max = 0f;
			min = 0f;
			for (int i = fromIndex; i < fromIndex + length; i++)
			{
				if (data[i] > max)
				{
					max = data[i];
				}
				else if (data[i] < min)
				{
					min = data[i];
				}
			}
		}

		public static void GetMaxAndMin(float[] data, int fromIndex, int length, out float min, out float max, int stride)
		{
			max = 0f;
			min = 0f;
			length += fromIndex;
			for (int i = fromIndex; i < length; i += stride)
			{
				if (data[i] > max)
				{
					max = data[i];
				}
				else if (data[i] < min)
				{
					min = data[i];
				}
			}
		}

		public static float GetAbsMaxValue(float[] data, int fromIndex, int length)
		{
			GetMaxAndMin(data, fromIndex, length, out var min, out var max);
			min = Mathf.Abs(min);
			if (min > max)
			{
				return min;
			}
			return max;
		}

		public static float GetAbsMaxValueFromInterleaved(float[] data, int fromIndex, int length, int channelNb, int nbOfChannels)
		{
			fromIndex += channelNb;
			GetMaxAndMin(data, fromIndex, length, out var min, out var max, nbOfChannels);
			min = Mathf.Abs(min);
			if (min > max)
			{
				return min;
			}
			return max;
		}

		public static void ClampData(float[] data, float minValue, float maxValue, out int nbOfClippedFloats)
		{
			nbOfClippedFloats = 0;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] > maxValue)
				{
					data[i] = maxValue;
					nbOfClippedFloats++;
				}
				else if (data[i] < minValue)
				{
					data[i] = minValue;
					nbOfClippedFloats++;
				}
			}
		}

		public static int GetIndexOfMaxValue(float[] data)
		{
			int result = 0;
			float num = 0f;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] > num)
				{
					result = i;
					num = data[i];
				}
			}
			return result;
		}

		public static int GetIndexOfMaxValue(float[] data, int first, int toIndex)
		{
			int result = 0;
			float num = 0f;
			for (int i = first; i < toIndex; i++)
			{
				if (data[i] > num)
				{
					result = i;
					num = data[i];
				}
			}
			return result;
		}

		public static int ClampedResampledLength(int sourceLength, int targetLength, double resamplingFactor)
		{
			int num = (int)((double)targetLength * resamplingFactor);
			if (sourceLength < num)
			{
				targetLength = (int)((double)sourceLength / resamplingFactor);
			}
			return targetLength;
		}

		public static int ResampledLength(int sourceLength, double resamplingFactor)
		{
			return (int)((double)sourceLength / resamplingFactor);
		}

		public static float GetRatioForInterval(float semiTones)
		{
			if (semiTones == 0f)
			{
				return 1f;
			}
			return Mathf.Pow(2f, semiTones / 12f);
		}

		public static float GetSemiTonesForRatio(float ratio)
		{
			return 12f * Mathf.Log(ratio, 2f);
		}

		public static bool IsPrime(int number)
		{
			if ((number & 1) == 1)
			{
				int num = (int)Mathf.Sqrt(number);
				for (int i = 3; i <= num; i += 2)
				{
					if (number % i == 0)
					{
						return false;
					}
				}
				return true;
			}
			return number == 2;
		}

		public static void MakeHanningWindow(float[] data)
		{
			int num = data.Length;
			for (int i = 0; i < num; i++)
			{
				data[i] = 0.5f * (1f - Mathf.Cos((float)Math.PI * 2f * (float)i / (float)num));
			}
		}

		public static void MakeHammingWindow(float[] data)
		{
			int num = data.Length;
			for (int i = 0; i < num; i++)
			{
				data[i] = 0.54f + 0.46f * Mathf.Cos((float)Math.PI * 2f * (float)i / (float)num);
			}
		}
	}
}
