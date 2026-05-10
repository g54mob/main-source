using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public struct SplineSample
	{
		public Vector3 position;

		public Vector3 up;

		public Vector3 forward;

		public Color color;

		public float size;

		public double percent;

		public Quaternion rotation => default(Quaternion);

		public Vector3 right => default(Vector3);

		public void FastCopy(ref SplineSample sample)
		{
		}

		public static SplineSample Lerp(ref SplineSample a, ref SplineSample b, float t)
		{
			return default(SplineSample);
		}

		public static SplineSample Lerp(ref SplineSample a, ref SplineSample b, double t)
		{
			return default(SplineSample);
		}

		public static void Lerp(ref SplineSample a, ref SplineSample b, double t, ref SplineSample target)
		{
		}

		public static void Lerp(ref SplineSample a, ref SplineSample b, float t, ref SplineSample target)
		{
		}

		public void Lerp(ref SplineSample b, double t)
		{
		}

		public void Lerp(ref SplineSample b, float t)
		{
		}

		public SplineSample(Vector3 position, Vector3 up, Vector3 forward, Color color, float size, double percent)
		{
			this.position = default(Vector3);
			this.up = default(Vector3);
			this.forward = default(Vector3);
			this.color = default(Color);
			this.size = 0f;
			this.percent = 0.0;
		}
	}
}
