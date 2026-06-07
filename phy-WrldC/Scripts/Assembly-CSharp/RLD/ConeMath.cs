using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class ConeMath
	{
		public static List<Vector3> CalcConeBaseExtentPoints(Vector3 coneBaseCenter, float coneBaseRadius, Quaternion coneRotation)
		{
			Vector3 vector = coneRotation * Vector3.right;
			Vector3 vector2 = coneRotation * Vector3.forward;
			return new List<Vector3>
			{
				coneBaseCenter + vector * coneBaseRadius,
				coneBaseCenter - vector2 * coneBaseRadius,
				coneBaseCenter - vector * coneBaseRadius,
				coneBaseCenter + vector2 * coneBaseRadius
			};
		}

		public static bool Raycast(Ray ray, out float t, Vector3 coneBaseCenter, float coneBaseRadius, float coneHeight, Quaternion coneRotation, ConeEpsilon epsilon = default(ConeEpsilon))
		{
			t = 0f;
			Ray ray2 = ray.InverseTransform(Matrix4x4.TRS(coneBaseCenter, coneRotation, Vector3.one));
			float num = coneBaseRadius * 2f;
			if (!BoxMath.Raycast(boxSize: new Vector3(num, coneHeight + epsilon.VertEps * 2f, num), ray: ray2, boxCenter: Vector3.up * coneHeight * 0.5f, boxRotation: Quaternion.identity))
			{
				return false;
			}
			if (new Plane(-Vector3.up, Vector3.zero).Raycast(ray2, out var enter) && (ray2.origin + ray2.direction * enter).magnitude <= coneBaseRadius)
			{
				t = enter;
				return true;
			}
			float num2 = coneBaseRadius / coneHeight;
			num2 *= num2;
			float a = ray2.direction.x * ray2.direction.x + ray2.direction.z * ray2.direction.z - num2 * ray2.direction.y * ray2.direction.y;
			float b = 2f * (ray2.origin.x * ray2.direction.x + ray2.origin.z * ray2.direction.z - num2 * ray2.direction.y * (ray2.origin.y - coneHeight));
			float c = ray2.origin.x * ray2.origin.x + ray2.origin.z * ray2.origin.z - num2 * (ray2.origin.y - coneHeight) * (ray2.origin.y - coneHeight);
			if (MathEx.SolveQuadratic(a, b, c, out var t2, out var t3))
			{
				if (t2 < 0f && t3 < 0f)
				{
					return false;
				}
				if (t2 < 0f)
				{
					float num3 = t2;
					t2 = t3;
					t3 = num3;
				}
				t = t2;
				Vector3 vector = ray2.origin + ray2.direction * t;
				if (vector.y < 0f - epsilon.VertEps || vector.y > coneHeight + epsilon.VertEps)
				{
					t = 0f;
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool ContainsPoint(Vector3 point, Vector3 coneBaseCenter, float coneBaseRadius, float coneHeight, Quaternion coneRotation, ConeEpsilon epsilon = default(ConeEpsilon))
		{
			point = Matrix4x4.TRS(coneBaseCenter, coneRotation, Vector3.one).inverse.MultiplyPoint(point);
			float num = Vector3.Dot(Vector3.up, point);
			if (num < 0f - epsilon.VertEps || num > coneHeight + epsilon.VertEps)
			{
				return false;
			}
			float num2 = coneHeight / coneBaseRadius;
			float num3 = num * num2;
			return point.GetDistanceToSegment(Vector3.zero, Vector3.up * coneHeight) <= num3 + epsilon.HrzEps;
		}
	}
}
