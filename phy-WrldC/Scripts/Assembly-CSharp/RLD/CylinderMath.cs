using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class CylinderMath
	{
		public static List<Vector3> CalcExtentPoints(Vector3 center, float cylinderRadius, Quaternion cylinderRotation)
		{
			Vector3 vector = cylinderRotation * Vector3.right;
			Vector3 vector2 = cylinderRotation * Vector3.forward;
			return new List<Vector3>
			{
				center + vector * cylinderRadius,
				center - vector2 * cylinderRadius,
				center - vector * cylinderRadius,
				center + vector2 * cylinderRadius
			};
		}

		public static bool Raycast(Ray ray, out float t, Vector3 cylinderAxisPt0, Vector3 cylinderAxisPt1, float cylinderRadius, CylinderEpsilon epsilon = default(CylinderEpsilon))
		{
			return Raycast(ray, out t, cylinderAxisPt0, cylinderAxisPt1, cylinderRadius, (cylinderAxisPt1 - cylinderAxisPt0).magnitude, epsilon);
		}

		public static bool Raycast(Ray ray, out float t, Vector3 cylinderAxisPt0, Vector3 cylinderAxisPt1, float cylinderRadius, float cylinderHeight, CylinderEpsilon epsilon = default(CylinderEpsilon))
		{
			t = 0f;
			cylinderRadius += epsilon.RadiusEps;
			Vector3 normalized = (cylinderAxisPt1 - cylinderAxisPt0).normalized;
			cylinderHeight += epsilon.VertEps * 2f;
			if (cylinderHeight < 1E-06f)
			{
				return false;
			}
			cylinderAxisPt0 -= normalized * epsilon.VertEps;
			cylinderAxisPt1 += normalized * epsilon.VertEps;
			float enter = 0f;
			float enter2 = 0f;
			bool flag = false;
			bool flag2 = false;
			if (new Plane(normalized, cylinderAxisPt0).Raycast(ray, out enter) && (ray.GetPoint(enter) - cylinderAxisPt0).sqrMagnitude <= cylinderRadius * cylinderRadius)
			{
				flag = true;
			}
			if (new Plane(normalized, cylinderAxisPt1).Raycast(ray, out enter2) && (ray.GetPoint(enter2) - cylinderAxisPt1).sqrMagnitude <= cylinderRadius * cylinderRadius)
			{
				flag2 = true;
			}
			Vector3 lhs = Vector3.Cross(ray.direction, normalized);
			Vector3 rhs = Vector3.Cross(ray.origin - cylinderAxisPt0, normalized);
			float sqrMagnitude = lhs.sqrMagnitude;
			float b = 2f * Vector3.Dot(lhs, rhs);
			float c = rhs.sqrMagnitude - cylinderRadius * cylinderRadius;
			if (MathEx.SolveQuadratic(sqrMagnitude, b, c, out var t2, out var t3))
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
				Vector3 vector = ray.origin + ray.direction * t;
				float num2 = Vector3.Dot(normalized, vector - cylinderAxisPt0);
				if (num2 < 0f)
				{
					if (!(flag2 || flag))
					{
						t = 0f;
						return false;
					}
					t = float.MaxValue;
					if (flag2)
					{
						t = enter2;
					}
					if (flag && t > enter)
					{
						t = enter;
					}
				}
				if (num2 > cylinderHeight)
				{
					if (!(flag2 || flag))
					{
						t = 0f;
						return false;
					}
					t = float.MaxValue;
					if (flag2)
					{
						t = enter2;
					}
					if (flag && t > enter)
					{
						t = enter;
					}
				}
				return true;
			}
			return false;
		}

		public static bool RaycastNoCaps(Ray ray, out float t, Vector3 cylinderAxisPt0, Vector3 cylinderAxisPt1, float cylinderRadius, CylinderEpsilon epsilon = default(CylinderEpsilon))
		{
			return RaycastNoCaps(ray, out t, cylinderAxisPt0, cylinderAxisPt1, cylinderRadius, (cylinderAxisPt1 - cylinderAxisPt0).magnitude, epsilon);
		}

		public static bool RaycastNoCaps(Ray ray, out float t, Vector3 cylinderAxisPt0, Vector3 cylinderAxisPt1, float cylinderRadius, float cylinderHeight, CylinderEpsilon epsilon = default(CylinderEpsilon))
		{
			t = 0f;
			cylinderRadius += epsilon.RadiusEps;
			Vector3 normalized = (cylinderAxisPt1 - cylinderAxisPt0).normalized;
			cylinderHeight += epsilon.VertEps * 2f;
			if (cylinderHeight < 1E-06f)
			{
				return false;
			}
			cylinderAxisPt0 -= normalized * epsilon.VertEps;
			cylinderAxisPt1 += normalized * epsilon.VertEps;
			Vector3 lhs = Vector3.Cross(ray.direction, normalized);
			Vector3 rhs = Vector3.Cross(ray.origin - cylinderAxisPt0, normalized);
			float sqrMagnitude = lhs.sqrMagnitude;
			float b = 2f * Vector3.Dot(lhs, rhs);
			float c = rhs.sqrMagnitude - cylinderRadius * cylinderRadius;
			if (MathEx.SolveQuadratic(sqrMagnitude, b, c, out var t2, out var t3))
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
				Vector3 vector = ray.origin + ray.direction * t;
				float num2 = Vector3.Dot(normalized, vector - cylinderAxisPt0);
				if (num2 < 0f)
				{
					t = 0f;
					return false;
				}
				if (num2 > cylinderHeight)
				{
					t = 0f;
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool ContainsPoint(Vector3 point, Vector3 cylinderAxisPt0, Vector3 cylinderAxisPt1, float cylinderRadius, CylinderEpsilon epsilon = default(CylinderEpsilon))
		{
			return ContainsPoint(point, cylinderAxisPt0, cylinderAxisPt1, cylinderRadius, (cylinderAxisPt1 - cylinderAxisPt0).magnitude, epsilon);
		}

		public static bool ContainsPoint(Vector3 point, Vector3 cylinderAxisPt0, Vector3 cylinderAxisPt1, float cylinderRadius, float cylinderHeight, CylinderEpsilon epsilon = default(CylinderEpsilon))
		{
			Vector3 normalized = (cylinderAxisPt1 - cylinderAxisPt0).normalized;
			Vector3 rhs = point - cylinderAxisPt0;
			float num = Vector3.Dot(normalized, rhs);
			if (num < 0f - epsilon.VertEps || num > cylinderHeight + epsilon.VertEps)
			{
				return false;
			}
			return (cylinderAxisPt0 + normalized * num - point).magnitude <= cylinderRadius + epsilon.RadiusEps;
		}
	}
}
