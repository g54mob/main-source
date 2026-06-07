using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class SphereMath
	{
		public static List<Vector3> CalcRightUpExtents(Vector3 sphereCenter, float sphereRadius, Vector3 right, Vector3 up)
		{
			return new List<Vector3>(4)
			{
				sphereCenter - right * sphereRadius,
				sphereCenter + up * sphereRadius,
				sphereCenter + right * sphereRadius,
				sphereCenter - up * sphereRadius
			};
		}

		public static bool Raycast(Ray ray, Vector3 sphereCenter, float sphereRadius, SphereEpsilon epsilon = default(SphereEpsilon))
		{
			float t;
			return Raycast(ray, out t, sphereCenter, sphereRadius, epsilon);
		}

		public static bool Raycast(Ray ray, out float t, Vector3 sphereCenter, float sphereRadius, SphereEpsilon epsilon = default(SphereEpsilon))
		{
			t = 0f;
			sphereRadius += epsilon.RadiusEps;
			Vector3 vector = ray.origin - sphereCenter;
			float a = Vector3.SqrMagnitude(ray.direction);
			float b = 2f * Vector3.Dot(ray.direction, vector);
			float c = Vector3.SqrMagnitude(vector) - sphereRadius * sphereRadius;
			if (MathEx.SolveQuadratic(a, b, c, out var t2, out var t3))
			{
				if (t2 < 0f && t3 < 0f)
				{
					return false;
				}
				if (t2 < 0f)
				{
					float num = t2;
					t2 = t3;
					t3 = num;
				}
				t = t2;
				return true;
			}
			return false;
		}

		public static bool Raycast(Ray ray, out float t0, out float t1, Vector3 sphereCenter, float sphereRadius, SphereEpsilon epsilon = default(SphereEpsilon))
		{
			t0 = (t1 = 0f);
			sphereRadius += epsilon.RadiusEps;
			Vector3 vector = ray.origin - sphereCenter;
			float a = Vector3.SqrMagnitude(ray.direction);
			float b = 2f * Vector3.Dot(ray.direction, vector);
			float c = Vector3.SqrMagnitude(vector) - sphereRadius * sphereRadius;
			if (MathEx.SolveQuadratic(a, b, c, out t0, out t1))
			{
				if (t0 < 0f && t1 < 0f)
				{
					return false;
				}
				if (t0 > t1)
				{
					float num = t0;
					t0 = t1;
					t1 = num;
				}
				if (t0 < 0f)
				{
					t0 = t1;
				}
				return true;
			}
			return false;
		}

		public static bool ContainsPoint(Vector3 point, Vector3 sphereCenter, float sphereRadius, SphereEpsilon epsilon = default(SphereEpsilon))
		{
			sphereRadius += epsilon.RadiusEps;
			return (point - sphereCenter).sqrMagnitude <= sphereRadius * sphereRadius;
		}
	}
}
