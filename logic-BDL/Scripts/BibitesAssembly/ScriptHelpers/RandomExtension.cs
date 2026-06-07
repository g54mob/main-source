using System;
using SettingScripts;
using UnityEngine;

namespace ScriptHelpers
{
	public static class RandomExtension
	{
		private static readonly FloatSetting RelativeMutationShare = ScenarioSettings.Instance.relativeMutationShare;

		private static float relativeMutationShare = RelativeMutationShare.SubscribeTo<FloatSetting, float>(UpdateRelativeMutationShare);

		private static void UpdateRelativeMutationShare(float val)
		{
			relativeMutationShare = val;
		}

		public static float NextGaussian(this System.Random r, float mu = 0f, float sig = 0f)
		{
			double d = 1.0 - r.NextDouble();
			double num = 1.0 - r.NextDouble();
			double num2 = Math.Sqrt(-2.0 * Math.Log(d)) * Math.Sin(Math.PI * 2.0 * num);
			return (float)((double)mu + (double)sig * num2);
		}

		public static float NextPowerGaussian(this System.Random r, float b = 2f)
		{
			float p = r.NextGaussian(0f, 1f);
			return Mathf.Pow(b, p);
		}

		public static float NextMutationValue(this System.Random r, float geneValue, float mutationSigma, float geneSpan, bool purelyRelative = false)
		{
			float num = (purelyRelative ? 1f : relativeMutationShare);
			float num2 = r.NextRelativeGaussianMutation(geneValue, mutationSigma * num);
			float num3 = r.NextGaussian(0f, mutationSigma * (1f - num)) * geneSpan;
			return num2 + num3;
		}

		public static float NextRelativeGaussianMutation(this System.Random r, float geneValue = 1f, float mutationSigma = 0f)
		{
			float p = r.NextGaussian(0f, 1f);
			float num = Mathf.Pow(1f + mutationSigma, p);
			return geneValue * (num - 1f);
		}

		public static int NextPoisson(this System.Random r, double lambda = 1.0)
		{
			double num = Math.Exp(0.0 - lambda);
			double num2 = 1.0;
			int num3 = 0;
			do
			{
				num3++;
				double num4 = r.NextDouble();
				num2 *= num4;
			}
			while (num2 > num);
			return num3 - 1;
		}

		public static Vector2 RandomPointInside2DCapsule(Vector2 dim)
		{
			float num = Mathf.Min(dim.x, dim.y) / 2f;
			Vector2 vector = UnityEngine.Random.insideUnitCircle * num;
			Vector2 vector2 = ((dim.x > dim.y) ? (Vector2.right * (dim.x - dim.y)) : (Vector2.up * (dim.y - dim.x)));
			return vector + (UnityEngine.Random.value - 0.5f) * vector2;
		}

		public static Vector2 RandomPointInRing(float outsideRadius, float insideRadiusRelative, float warp = 1f)
		{
			Vector2 normalized = UnityEngine.Random.insideUnitCircle.normalized;
			float num = insideRadiusRelative * insideRadiusRelative;
			float num2 = (Mathf.Sqrt(UnityEngine.Random.value * (1f - num) + num) - insideRadiusRelative) / (1f - insideRadiusRelative);
			float num3 = (1f + Mathf.Pow(num2, 1f / warp) - Mathf.Pow(1f - num2, 1f / warp)) / 2f * (1f - insideRadiusRelative) + insideRadiusRelative;
			return normalized * (outsideRadius * num3);
		}
	}
}
