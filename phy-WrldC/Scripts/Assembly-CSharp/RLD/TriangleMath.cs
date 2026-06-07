using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class TriangleMath
	{
		private static readonly float _eqTriangleAltFactor = Mathf.Sqrt(3f) * 0.5f;

		public static float EqTriangleAltFactor => _eqTriangleAltFactor;

		public static float GetEqTriangleAltitude(float sideLength)
		{
			return sideLength * _eqTriangleAltFactor;
		}

		public static float GetEqTriangleCentroidAltitude(float sideLength)
		{
			return sideLength * _eqTriangleAltFactor / 3f;
		}

		public static List<Vector3> CalcEqTriangle3DPoints(Vector3 centroid, float sideLength, Quaternion rotation)
		{
			float num = sideLength * 0.5f;
			float eqTriangleCentroidAltitude = GetEqTriangleCentroidAltitude(sideLength);
			Vector3 vector = centroid - rotation * Vector3.up * eqTriangleCentroidAltitude;
			return new List<Vector3>
			{
				vector - rotation * Vector3.right * num,
				centroid + rotation * Vector3.up * (GetEqTriangleAltitude(sideLength) - eqTriangleCentroidAltitude),
				vector + rotation * Vector3.right * num
			};
		}

		public static List<Vector2> CalcEqTriangle2DPoints(Vector2 centroid, float sideLength, Quaternion rotation)
		{
			float num = sideLength * 0.5f;
			float eqTriangleCentroidAltitude = GetEqTriangleCentroidAltitude(sideLength);
			Vector2 vector = rotation * Vector2.right;
			Vector2 vector2 = rotation * Vector2.up;
			Vector2 vector3 = centroid - vector2 * eqTriangleCentroidAltitude;
			return new List<Vector2>
			{
				vector3 - vector * num,
				centroid + vector2 * (GetEqTriangleAltitude(sideLength) - eqTriangleCentroidAltitude),
				vector3 + vector * num
			};
		}

		public static float CalcRATriangleHypotenuse(float side0, float side1)
		{
			return Mathf.Sqrt(side0 * side0 + side1 * side1);
		}

		public static float CalcRATriangleHypotenuse(Vector2 sides)
		{
			return Mathf.Sqrt(sides.x * sides.x + sides.y * sides.y);
		}

		public static float CalcRATriangleAltitude(Vector2 sides)
		{
			return sides.x * sides.y / Mathf.Sqrt(sides.x * sides.x + sides.y * sides.y);
		}

		public static List<Vector3> CalcRATriangle3DPoints(Vector3 rightAngleCorner, float xLength, float yLength, Quaternion triangleRotation)
		{
			Vector3 vector = triangleRotation * Vector3.right;
			Vector3 vector2 = triangleRotation * Vector3.up;
			return new List<Vector3>
			{
				rightAngleCorner,
				rightAngleCorner + vector2 * yLength,
				rightAngleCorner + vector * xLength
			};
		}

		public static List<Vector2> CalcRATriangle2DPoints(Vector2 rightAngleCorner, float xLength, float yLength, float degreeTriRotation)
		{
			Quaternion quaternion = Quaternion.AngleAxis(degreeTriRotation, Vector3.forward);
			Vector2 vector = quaternion * Vector2.right;
			Vector2 vector2 = quaternion * Vector2.up;
			return new List<Vector2>
			{
				rightAngleCorner,
				rightAngleCorner + vector2 * yLength,
				rightAngleCorner + vector * xLength
			};
		}

		public static OBB Calc3DTriangleOBB(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 normal, TriangleEpsilon epsilon = default(TriangleEpsilon))
		{
			Vector3 vector = p0;
			Vector3 vector2 = p1;
			Vector3 vector3 = p2;
			float num = (p0 - p1).sqrMagnitude + 1E-05f;
			float sqrMagnitude = (p1 - p2).sqrMagnitude;
			if (sqrMagnitude > num)
			{
				vector = p1;
				vector2 = p2;
				vector3 = p0;
				num = sqrMagnitude;
			}
			sqrMagnitude = (p2 - p0).sqrMagnitude;
			if (sqrMagnitude > num)
			{
				vector = p2;
				vector2 = p0;
				vector3 = p1;
				num = sqrMagnitude;
			}
			Quaternion rotation = Quaternion.LookRotation((vector2 - vector).normalized, normal);
			OBB result = new OBB(rotation);
			float num2 = 2f * epsilon.AreaEps;
			float num3 = Mathf.Sqrt(num) + num2;
			float f = Vector3.Dot(result.Right, vector3 - vector);
			float num4 = Mathf.Abs(f) + num2;
			float y = epsilon.ExtrudeEps * 2f;
			result.Size = new Vector3(num4, y, num3);
			Vector3 vector4 = result.Right * Mathf.Sign(f);
			result.Center = vector4 * num4 * 0.5f - vector4 * epsilon.AreaEps + vector - result.Look * epsilon.AreaEps + result.Look * num3 * 0.5f;
			return result;
		}

		public static bool Raycast(Ray ray, out float t, Vector3 p0, Vector3 p1, Vector3 p2, TriangleEpsilon epsilon = default(TriangleEpsilon))
		{
			t = 0f;
			Plane plane = new Plane(p0, p1, p2);
			if (plane.Raycast(ray, out var enter) && Contains3DPoint(ray.GetPoint(enter), checkOnPlane: false, p0, p1, p2, epsilon))
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(plane.normal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = Calc3DTriangleOBB(p0, p1, p2, plane.normal, epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool RaycastWire(Ray ray, out float t, Vector3 p0, Vector3 p1, Vector3 p2, TriangleEpsilon epsilon = default(TriangleEpsilon))
		{
			t = 0f;
			Plane plane = new Plane(p0, p1, p2);
			if (plane.Raycast(ray, out var enter))
			{
				Vector3 point = ray.GetPoint(enter);
				if (point.GetDistanceToSegment(p0, p1) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
				if (point.GetDistanceToSegment(p1, p2) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
				if (point.GetDistanceToSegment(p2, p0) <= epsilon.WireEps)
				{
					t = enter;
					return true;
				}
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(plane.normal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = Calc3DTriangleOBB(p0, p1, p2, plane.normal, epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool Contains3DPoint(Vector3 point, bool checkOnPlane, Vector3 p0, Vector3 p1, Vector3 p2, TriangleEpsilon epsilon = default(TriangleEpsilon))
		{
			Vector3 lhs = p1 - p0;
			Vector3 lhs2 = p2 - p1;
			Vector3 vector = p0 - p2;
			Vector3 normalized = Vector3.Cross(lhs, -vector).normalized;
			if (checkOnPlane && Mathf.Abs(Vector3.Dot(point - p0, normalized)) > epsilon.ExtrudeEps)
			{
				return false;
			}
			Vector3 normalized2 = Vector3.Cross(lhs, normalized).normalized;
			if (Vector3.Dot(point - p0, normalized2) > epsilon.AreaEps)
			{
				return false;
			}
			normalized2 = Vector3.Cross(lhs2, normalized).normalized;
			if (Vector3.Dot(point - p1, normalized2) > epsilon.AreaEps)
			{
				return false;
			}
			normalized2 = Vector3.Cross(vector, normalized).normalized;
			if (Vector3.Dot(point - p2, normalized2) > epsilon.AreaEps)
			{
				return false;
			}
			return true;
		}

		public static bool Contains2DPoint(Vector2 point, Vector2 p0, Vector2 p1, Vector2 p2, TriangleEpsilon epsilon = default(TriangleEpsilon))
		{
			return Contains3DPoint(point, checkOnPlane: false, p0, p1, p2, epsilon);
		}
	}
}
