using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtVector4D
	{
		public double x;

		public double y;

		public double z;

		public double w;

		public double sqrMagnitude => 0.0;

		public double magnitude => 0.0;

		public SgtVector4D normalized => default(SgtVector4D);

		public SgtVector4D(double newX, double newY, double newZ, double newW)
		{
			x = 0.0;
			y = 0.0;
			z = 0.0;
			w = 0.0;
		}

		public SgtVector4D(Vector4 v)
		{
			x = 0.0;
			y = 0.0;
			z = 0.0;
			w = 0.0;
		}

		public static double Dot(SgtVector4D a, SgtVector4D b)
		{
			return 0.0;
		}

		public static double SquareDistance(SgtVector4D a, SgtVector4D b)
		{
			return 0.0;
		}

		public static SgtVector4D operator -(SgtVector4D a)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator -(SgtVector4D a, SgtVector4D b)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator +(SgtVector4D a, SgtVector4D b)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator /(SgtVector4D a, long b)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator /(SgtVector4D a, double b)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator *(SgtVector4D a, long b)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator *(SgtVector4D a, double b)
		{
			return default(SgtVector4D);
		}

		public static SgtVector4D operator *(long a, SgtVector4D b)
		{
			return default(SgtVector4D);
		}

		public static explicit operator Vector4(SgtVector4D a)
		{
			return default(Vector4);
		}
	}
}
