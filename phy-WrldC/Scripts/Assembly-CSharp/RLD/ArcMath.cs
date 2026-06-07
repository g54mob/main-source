using System;
using UnityEngine;

namespace RLD
{
	public static class ArcMath
	{
		public static float ConvertToSh3DArcAngle(Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart)
		{
			degreesFromStart %= 360f;
			if (Mathf.Abs(degreesFromStart) > 180f)
			{
				Vector3 vector = arcStartPoint - arcOrigin;
				Vector3 normalized = (Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector).normalized;
				degreesFromStart = Vector3Ex.SignedAngle(vector, normalized, arcPlaneNormal);
			}
			return degreesFromStart;
		}

		public static float ConvertToSh2DArcAngle(Vector2 arcOrigin, Vector2 arcStartPoint, float degreesFromStart)
		{
			degreesFromStart %= 360f;
			if (Mathf.Abs(degreesFromStart) > 180f)
			{
				Vector2 vector = arcStartPoint - arcOrigin;
				Vector2 vector2 = (Quaternion.AngleAxis(degreesFromStart, Vector3.forward) * vector).normalized;
				degreesFromStart = Vector3Ex.SignedAngle(vector, vector2, Vector3.forward);
			}
			return degreesFromStart;
		}

		public static OBB CalcSh3DArcOBB(Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			degreesFromStart = ConvertToSh3DArcAngle(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart);
			Vector3 vector = arcStartPoint - arcOrigin;
			Vector3 vector2 = Quaternion.AngleAxis(degreesFromStart * 0.5f, arcPlaneNormal) * vector;
			Vector3 vector3 = arcOrigin + vector2;
			Quaternion rotation = Quaternion.LookRotation(vector2.normalized, arcPlaneNormal);
			Vector3 center = arcOrigin + vector2 * 0.5f;
			OBB result = new OBB(center, rotation);
			Vector3 v = Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector;
			float num = 2f * epsilon.AreaEps;
			float x = v.AbsDot(result.Right) + vector.AbsDot(result.Right) + num;
			float z = vector3.magnitude + num;
			float y = epsilon.ExtrudeEps * 2f;
			result.Size = new Vector3(x, y, z);
			return result;
		}

		public static OBB CalcLg3DArcOBB(Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			if (Math.Abs(degreesFromStart) <= 180f)
			{
				return CalcSh3DArcOBB(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
			}
			Vector3 vector = arcStartPoint - arcOrigin;
			Vector3 vector2 = Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector;
			Vector3 vector3 = arcOrigin + vector2 - arcStartPoint;
			Vector3 vector4 = arcStartPoint + vector3 * 0.5f;
			Vector3 vector5 = vector4 - arcOrigin;
			Vector3 vector6 = vector4 + vector5.normalized * epsilon.AreaEps;
			float magnitude = (arcOrigin - arcStartPoint).magnitude;
			float num = magnitude + vector5.magnitude + 2f * epsilon.AreaEps;
			Quaternion rotation = Quaternion.LookRotation(vector5.normalized, arcPlaneNormal);
			Vector3 center = vector6 - vector5.normalized * num * 0.5f;
			OBB result = new OBB(center, rotation);
			float x = (magnitude + epsilon.AreaEps) * 2f;
			float y = epsilon.ExtrudeEps * 2f;
			result.Size = new Vector3(x, y, num);
			return result;
		}

		public static bool RaycastShArc(Ray ray, out float t, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			t = 0f;
			degreesFromStart = ConvertToSh3DArcAngle(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart);
			if (new Plane(arcPlaneNormal, arcOrigin).Raycast(ray, out var enter) && ShArcContains3DPoint(ray.GetPoint(enter), checkOnPlane: false, arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon))
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(arcPlaneNormal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = CalcSh3DArcOBB(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool RaycastShArcWire(Ray ray, out float t, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			t = 0f;
			degreesFromStart = ConvertToSh3DArcAngle(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart);
			if (new Plane(arcPlaneNormal, arcOrigin).Raycast(ray, out var enter) && Is3DPointOnShArcWire(ray.GetPoint(enter), checkOnPlane: false, arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon))
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(arcPlaneNormal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = CalcSh3DArcOBB(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool RaycastLgArc(Ray ray, out float t, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			t = 0f;
			if (new Plane(arcPlaneNormal, arcOrigin).Raycast(ray, out var enter) && LgArcContains3DPoint(ray.GetPoint(enter), checkOnPlane: false, arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon))
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(arcPlaneNormal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = CalcLg3DArcOBB(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool RaycastLgArcWire(Ray ray, out float t, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			t = 0f;
			if (new Plane(arcPlaneNormal, arcOrigin).Raycast(ray, out var enter) && Is3DPointOnLgArcWire(ray.GetPoint(enter), checkOnPlane: false, arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon))
			{
				t = enter;
				return true;
			}
			if (epsilon.ExtrudeEps != 0f && ray.direction.AbsDot(arcPlaneNormal) < ExtrudeEpsThreshold.Get)
			{
				OBB oBB = CalcLg3DArcOBB(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
				return BoxMath.Raycast(ray, oBB.Center, oBB.Size, oBB.Rotation);
			}
			return false;
		}

		public static bool ShArcContains3DPoint(Vector3 point, bool checkOnPlane, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			Vector3 vector = arcStartPoint - arcOrigin;
			Vector3 to = point - arcOrigin;
			if ((arcOrigin - arcStartPoint).magnitude + epsilon.AreaEps < to.magnitude)
			{
				return false;
			}
			Plane plane = new Plane(arcPlaneNormal, arcOrigin);
			if (checkOnPlane && plane.GetAbsDistanceToPoint(point) > epsilon.ExtrudeEps)
			{
				return false;
			}
			float f = Vector3Ex.SignedAngle(vector, to, arcPlaneNormal);
			if (Mathf.Sign(f) == Mathf.Sign(degreesFromStart) && Mathf.Abs(f) <= Mathf.Abs(degreesFromStart))
			{
				return true;
			}
			if (epsilon.AreaEps != 0f)
			{
				Vector3 point2 = Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector + arcOrigin;
				if (point.GetDistanceToSegment(arcOrigin, arcStartPoint) <= epsilon.AreaEps)
				{
					return true;
				}
				if (point.GetDistanceToSegment(arcOrigin, point2) <= epsilon.AreaEps)
				{
					return true;
				}
			}
			return false;
		}

		public static bool Is3DPointOnShArcWire(Vector3 point, bool checkOnPlane, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			Vector3 vector = arcStartPoint - arcOrigin;
			Vector3 to = point - arcOrigin;
			float magnitude = to.magnitude;
			float magnitude2 = (arcOrigin - arcStartPoint).magnitude;
			Plane plane = new Plane(arcPlaneNormal, arcOrigin);
			if (checkOnPlane && plane.GetAbsDistanceToPoint(point) > epsilon.ExtrudeEps)
			{
				return false;
			}
			float f = Vector3Ex.SignedAngle(vector, to, arcPlaneNormal);
			if (Mathf.Sign(f) == Mathf.Sign(degreesFromStart) && Mathf.Abs(f) <= Mathf.Abs(degreesFromStart) && magnitude >= magnitude2 - epsilon.WireEps && magnitude <= magnitude2 + epsilon.WireEps)
			{
				return true;
			}
			Vector3 point2 = Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector + arcOrigin;
			if (point.GetDistanceToSegment(arcOrigin, arcStartPoint) <= epsilon.WireEps)
			{
				return true;
			}
			if (point.GetDistanceToSegment(arcOrigin, point2) <= epsilon.WireEps)
			{
				return true;
			}
			return false;
		}

		public static bool ShArcContains2DPoint(Vector2 point, Vector2 arcOrigin, Vector2 arcStartPoint, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			degreesFromStart = ConvertToSh2DArcAngle(arcOrigin, arcStartPoint, degreesFromStart);
			epsilon.ExtrudeEps = 0f;
			return ShArcContains3DPoint(point.ToVector3(), checkOnPlane: false, arcOrigin.ToVector3(), arcStartPoint.ToVector3(), Vector3.forward, degreesFromStart, epsilon);
		}

		public static bool LgArcContains3DPoint(Vector3 point, bool checkOnPlane, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			degreesFromStart %= 360f;
			if (Mathf.Abs(degreesFromStart) <= 180f)
			{
				return ShArcContains3DPoint(point, checkOnPlane, arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
			}
			Vector3 to = point - arcOrigin;
			Vector3 vector = arcStartPoint - arcOrigin;
			degreesFromStart = ConvertToSh3DArcAngle(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart);
			float f = Vector3Ex.SignedAngle(vector, to, arcPlaneNormal);
			if (Mathf.Sign(f) == Mathf.Sign(degreesFromStart) && Mathf.Abs(f) <= Mathf.Abs(degreesFromStart) && epsilon.AreaEps != 0f)
			{
				Vector3 point2 = Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector + arcOrigin;
				if (point.GetDistanceToSegment(arcOrigin, arcStartPoint) <= epsilon.AreaEps)
				{
					return true;
				}
				if (point.GetDistanceToSegment(arcOrigin, point2) <= epsilon.AreaEps)
				{
					return true;
				}
				return false;
			}
			float num = (arcOrigin - arcStartPoint).magnitude + epsilon.AreaEps;
			return to.magnitude <= num;
		}

		public static bool Is3DPointOnLgArcWire(Vector3 point, bool checkOnPlane, Vector3 arcOrigin, Vector3 arcStartPoint, Vector3 arcPlaneNormal, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			if (Mathf.Abs(degreesFromStart) <= 180f)
			{
				return Is3DPointOnShArcWire(point, checkOnPlane, arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart, epsilon);
			}
			Vector3 vector = arcStartPoint - arcOrigin;
			Vector3 to = point - arcOrigin;
			float magnitude = to.magnitude;
			float magnitude2 = (arcOrigin - arcStartPoint).magnitude;
			Plane plane = new Plane(arcPlaneNormal, arcOrigin);
			if (checkOnPlane && plane.GetAbsDistanceToPoint(point) > epsilon.ExtrudeEps)
			{
				return false;
			}
			Vector3 point2 = Quaternion.AngleAxis(degreesFromStart, arcPlaneNormal) * vector + arcOrigin;
			if (point.GetDistanceToSegment(arcOrigin, arcStartPoint) <= epsilon.WireEps)
			{
				return true;
			}
			if (point.GetDistanceToSegment(arcOrigin, point2) <= epsilon.WireEps)
			{
				return true;
			}
			degreesFromStart = ConvertToSh3DArcAngle(arcOrigin, arcStartPoint, arcPlaneNormal, degreesFromStart);
			float f = Vector3Ex.SignedAngle(vector, to, arcPlaneNormal);
			if (Mathf.Sign(f) == Mathf.Sign(degreesFromStart) && Mathf.Abs(f) <= Mathf.Abs(degreesFromStart))
			{
				return false;
			}
			if (magnitude >= magnitude2 - epsilon.WireEps)
			{
				return magnitude <= magnitude2 + epsilon.WireEps;
			}
			return false;
		}

		public static bool LgArcContains2DPoint(Vector2 point, Vector2 arcOrigin, Vector2 arcStartPoint, float degreesFromStart, ArcEpsilon epsilon = default(ArcEpsilon))
		{
			epsilon.ExtrudeEps = 0f;
			return LgArcContains3DPoint(point.ToVector3(), checkOnPlane: false, arcOrigin.ToVector3(), arcStartPoint.ToVector3(), Vector3.forward, degreesFromStart, epsilon);
		}
	}
}
