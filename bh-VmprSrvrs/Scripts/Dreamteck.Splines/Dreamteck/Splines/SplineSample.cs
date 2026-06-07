using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class SplineSample
	{
		public Vector3 position;

		public Vector3 up;

		public Vector3 forward;

		public Color color;

		public float size;

		public double percent;

		public Quaternion rotation => default(Quaternion);

		public Vector3 right => default(Vector3);

		public static SplineSample Lerp(SplineSample a, SplineSample b, float t)
		{
			return null;
		}

		public static SplineSample Lerp(SplineSample a, SplineSample b, double t)
		{
			return null;
		}

		public static void Lerp(SplineSample a, SplineSample b, double t, SplineSample target)
		{
		}

		public static void Lerp(SplineSample a, SplineSample b, float t, SplineSample target)
		{
		}

		public void Lerp(SplineSample b, double t)
		{
		}

		public void Lerp(SplineSample b, float t)
		{
		}

		public void CopyFrom(SplineSample input)
		{
		}

		public SplineSample()
		{
		}

		public SplineSample(Vector3 position, Vector3 normal, Vector3 direction, Color color, float size, double percent)
		{
		}

		public SplineSample(SplineSample input)
		{
		}
	}
}
