using System;
using UnityEngine;

namespace TH20
{
	public static class RandomUtils
	{
		public static readonly System.Random GlobalRandomInstance = new System.Random();

		public static char RandomUpperCaseCharacter(System.Random random)
		{
			return (char)(65 + random.Next(0, 26));
		}

		public static Vector3 RandomPositionInCircle(Vector3 centre, float distance, System.Random random)
		{
			return centre + Quaternion.AngleAxis(random.NextFloat(0f, 360f), Vector3.up) * new Vector3(0f, 0f, random.NextFloat(0f, distance));
		}

		public static Vector3 RandomXZVector(float min, float max, System.Random random)
		{
			return new Vector3(random.NextFloat(min, max), 0f, random.NextFloat(min, max));
		}

		public static Vector3 RandomXZVector(float min, float max)
		{
			return RandomXZVector(min, max, GlobalRandomInstance);
		}

		public static double RandomNormallyDistributedDouble(double mean, double standardDeviation, System.Random random)
		{
			double d = random.NextDouble();
			double num = random.NextDouble();
			double num2 = Math.Sqrt(-2.0 * Math.Log(d)) * Math.Sin(Math.PI * 2.0 * num);
			return mean + standardDeviation * num2;
		}

		public static float RandomNormallyDistributedFloat(float mean, float standardDeviation, System.Random random)
		{
			float f = (float)random.NextDouble();
			float num = (float)random.NextDouble();
			float num2 = Mathf.Sqrt(-2f * Mathf.Log(f)) * Mathf.Sin((float)Math.PI * 2f * num);
			return mean + standardDeviation * num2;
		}

		public static double RandomNormallyDistributedDoubleInRange(double mean, double halfRange, System.Random random)
		{
			return MathUtils.Clamp(RandomNormallyDistributedDouble(mean, halfRange / 3.0, random), mean - halfRange, mean + halfRange);
		}

		public static float RandomNormallyDistributedFloatInRange(float mean, float halfRange, System.Random random)
		{
			return Mathf.Clamp(RandomNormallyDistributedFloat(mean, halfRange / 3f, random), mean - halfRange, mean + halfRange);
		}

		public static int RandomIndexFromProbabilityMassFunction(float[] probabilityMassFunction, System.Random random)
		{
			if (probabilityMassFunction.Length <= 1)
			{
				return 0;
			}
			float num = 0f;
			for (int i = 0; i < probabilityMassFunction.Length; i++)
			{
				num += probabilityMassFunction[i];
			}
			float num2 = random.NextFloat(0f, num);
			float num3 = 0f;
			for (int j = 0; j < probabilityMassFunction.Length; j++)
			{
				num3 += probabilityMassFunction[j];
				if (num2 < num3)
				{
					return j;
				}
			}
			return probabilityMassFunction.Length - 1;
		}

		public static double NextDouble(this System.Random random, double min, double max)
		{
			return random.NextDouble() * (max - min) + min;
		}

		public static float NextFloat(this System.Random random)
		{
			return (float)random.NextDouble();
		}

		public static float NextFloat(this System.Random random, float min, float max)
		{
			return (float)random.NextDouble() * (max - min) + min;
		}

		public static Color RandomColor(System.Random random)
		{
			return new Color(random.NextFloat(), random.NextFloat(), random.NextFloat(), 1f);
		}

		public static Color RandomColor()
		{
			return RandomColor(GlobalRandomInstance);
		}
	}
}
