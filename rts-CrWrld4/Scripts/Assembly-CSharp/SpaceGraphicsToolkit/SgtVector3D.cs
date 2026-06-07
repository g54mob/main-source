using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[Serializable]
	public struct SgtVector3D
	{
		public double x;

		public double y;

		public double z;

		public double sqrMagnitude => 0.0;

		public double magnitude => 0.0;

		public SgtVector3D normalized => default(SgtVector3D);

		public SgtVector3D(double newX, double newY, double newZ)
		{
			x = 0.0;
			y = 0.0;
			z = 0.0;
		}

		public SgtVector3D(Vector3 v)
		{
			x = 0.0;
			y = 0.0;
			z = 0.0;
		}

		public static double Dot(SgtVector3D a, SgtVector3D b)
		{
			return 0.0;
		}

		public static SgtVector3D Lerp(SgtVector3D a, SgtVector3D b, double t)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D Cross(SgtVector3D a, SgtVector3D b)
		{
			return default(SgtVector3D);
		}

		public static bool Overlap(SgtVector3D a, SgtVector3D b, SgtVector3D c, SgtVector3D d, double eps = 0.001)
		{
			return false;
		}

		public static bool Overlap(SgtVector3D a, SgtVector3D b, SgtVector3D p, float eps = 0.001f)
		{
			return false;
		}

		public static double SquareDistance(SgtVector3D a, SgtVector3D b)
		{
			return 0.0;
		}

		public static SgtVector3D operator -(SgtVector3D a)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator -(SgtVector3D a, SgtVector3D b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator +(SgtVector3D a, SgtVector3D b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator /(SgtVector3D a, long b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator /(SgtVector3D a, double b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator *(SgtVector3D a, long b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator *(SgtVector3D a, double b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator *(long a, SgtVector3D b)
		{
			return default(SgtVector3D);
		}

		public static SgtVector3D operator *(SgtVector3D point, Quaternion rotation)
		{
			return default(SgtVector3D);
		}

		public static explicit operator Vector3(SgtVector3D a)
		{
			return default(Vector3);
		}
	}
}
