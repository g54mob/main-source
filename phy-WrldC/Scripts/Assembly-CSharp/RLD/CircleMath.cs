using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class CircleMath
	{
		public static List<Vector3> Calc3DExtentPoints(Vector3 circleCenter, float circleRadius, Quaternion circleRotation)
		{
			Vector3 vector = circleRotation * Vector3.right;
			Vector3 vector2 = circleRotation * Vector3.up;
			return new List<Vector3>
			{
				circleCenter + vector2 * circleRadius,
				circleCenter + vector * circleRadius,
				circleCenter - vector2 * circleRadius,
				circleCenter - vector * circleRadius
			};
		}

		public static List<Vector2> Calc2DExtentPoints(Vector2 circleCenter, float circleRadius, float degreeCircleRotation)
		{
			Quaternion quaternion = Quaternion.AngleAxis(degreeCircleRotation, Vector3.forward);
			Vector2 vector = quaternion * Vector2.right;
			Vector2 vector2 = quaternion * Vector2.up;
			return new List<Vector2>
			{
				circleCenter + vector2 * circleRadius,
				circleCenter + vector * circleRadius,
				circleCenter - vector2 * circleRadius,
				circleCenter - vector * circleRadius
			};
		}

		public static bool Raycast(Ray ray, out float t, Vector3 circleCenter, float circleRadius, Vector3 circleNormal, CircleEpsilon epsilon = default(CircleEpsilon))
		{
			t = 0f;
			circleRadius += epsilon.RadiusEps;
			if (new Plane(circleNormal, circleCenter).Raycast(ray, out var enter) && (ray.GetPoint(enter) - circleCenter).magnitude <= circleRadius)
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(circleNormal) < ExtrudeEpsThreshold.Get)
			{
				Vector3 cylinderAxisPt = circleCenter - circleNormal * epsilon.ExtrudeEps;
				Vector3 cylinderAxisPt2 = circleCenter + circleNormal * epsilon.ExtrudeEps;
				return CylinderMath.Raycast(ray, out t, cylinderAxisPt, cylinderAxisPt2, circleRadius);
			}
			return false;
		}

		public static bool RaycastWire(Ray ray, out float t, Vector3 circleCenter, float circleRadius, Vector3 circleNormal, CircleEpsilon epsilon = default(CircleEpsilon))
		{
			t = 0f;
			if (new Plane(circleNormal, circleCenter).Raycast(ray, out var enter))
			{
				Vector3 point = ray.GetPoint(enter);
				float magnitude = (circleCenter - point).magnitude;
				if (magnitude >= circleRadius - epsilon.WireEps && magnitude <= circleRadius + epsilon.WireEps)
				{
					t = enter;
					return true;
				}
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(circleNormal) < ExtrudeEpsThreshold.Get)
			{
				Vector3 cylinderAxisPt = circleCenter - circleNormal * epsilon.ExtrudeEps;
				Vector3 cylinderAxisPt2 = circleCenter + circleNormal * epsilon.ExtrudeEps;
				return CylinderMath.Raycast(ray, out t, cylinderAxisPt, cylinderAxisPt2, circleRadius + epsilon.WireEps);
			}
			return false;
		}

		public static bool Contains3DPoint(Vector3 point, bool checkOnPlane, Vector3 circleCenter, float circleRadius, Vector3 circleNormal, CircleEpsilon epsilon = default(CircleEpsilon))
		{
			Plane plane = new Plane(circleNormal, circleCenter);
			if (checkOnPlane && plane.GetAbsDistanceToPoint(point) > epsilon.ExtrudeEps)
			{
				return false;
			}
			circleRadius += epsilon.RadiusEps;
			point = plane.ProjectPoint(point);
			return (point - circleCenter).magnitude <= circleRadius;
		}

		public static bool Contains2DPoint(Vector2 point, Vector2 circleCenter, float circleRadius, CircleEpsilon epsilon = default(CircleEpsilon))
		{
			circleRadius += epsilon.RadiusEps;
			return (point - circleCenter).magnitude <= circleRadius;
		}

		public static bool Is2DPointOnBorder(Vector2 point, Vector2 circleCenter, float circleRadius, CircleEpsilon epsilon = default(CircleEpsilon))
		{
			float magnitude = (point - circleCenter).magnitude;
			if (magnitude >= circleRadius - epsilon.WireEps)
			{
				return magnitude <= circleRadius + epsilon.WireEps;
			}
			return false;
		}
	}
}
