using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtVector2D
	{
		public double x;

		public double y;

		public double sqrMagnitude => 0.0;

		public double magnitude => 0.0;

		public SgtVector2D normalized => default(SgtVector2D);

		public SgtVector2D(double newX, double newY)
		{
			x = 0.0;
			y = 0.0;
		}

		public SgtVector2D(Vector2 v)
		{
			x = 0.0;
			y = 0.0;
		}

		public static SgtVector2D operator -(SgtVector2D a, SgtVector2D b)
		{
			return default(SgtVector2D);
		}

		public static SgtVector2D operator +(SgtVector2D a, SgtVector2D b)
		{
			return default(SgtVector2D);
		}

		public static SgtVector2D operator /(SgtVector2D a, long b)
		{
			return default(SgtVector2D);
		}

		public static SgtVector2D operator /(SgtVector2D a, double b)
		{
			return default(SgtVector2D);
		}

		public static SgtVector2D operator *(SgtVector2D a, long b)
		{
			return default(SgtVector2D);
		}

		public static SgtVector2D operator *(SgtVector2D a, double b)
		{
			return default(SgtVector2D);
		}

		public static SgtVector2D operator *(long a, SgtVector2D b)
		{
			return default(SgtVector2D);
		}

		public static explicit operator Vector2(SgtVector2D a)
		{
			return default(Vector2);
		}
	}
}
