using System.Runtime.CompilerServices;
using UnityEngine;

public static class VectorUtils
{
	public static Vector3 ProjectPointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
	{
		Vector3 rhs = point - lineStart;
		Vector3 vector = lineEnd - lineStart;
		float magnitude = vector.magnitude;
		Vector3 vector2 = vector;
		if (magnitude > 1E-06f)
		{
			vector2 /= magnitude;
		}
		float value = Vector3.Dot(vector2, rhs);
		value = Mathf.Clamp(value, 0f, magnitude);
		return lineStart + vector2 * value;
	}

	public static float DistancePointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
	{
		return Vector3.Magnitude(ProjectPointLine(point, lineStart, lineEnd) - point);
	}

	public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
	{
		Vector3 vector = b - a;
		return Mathf.Clamp01(Vector3.Dot(value - a, vector) / Vector3.Dot(vector, vector));
	}

	public static float InverseLerpUnclamped(Vector3 a, Vector3 b, Vector3 value)
	{
		Vector3 vector = b - a;
		return Vector3.Dot(value - a, vector) / Vector3.Dot(vector, vector);
	}

	public static (bool success, Vector3 point1, Vector3 point2) ClosestPointsOnTwoLines(Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		float num = Vector3.Dot(lineVec1, lineVec1);
		float num2 = Vector3.Dot(lineVec1, lineVec2);
		float num3 = Vector3.Dot(lineVec2, lineVec2);
		float num4 = num * num3 - num2 * num2;
		if (!Mathf.Approximately(num4, 0f))
		{
			Vector3 rhs = linePoint1 - linePoint2;
			float num5 = Vector3.Dot(lineVec1, rhs);
			float num6 = Vector3.Dot(lineVec2, rhs);
			float num7 = (num2 * num6 - num5 * num3) / num4;
			float num8 = (num * num6 - num5 * num2) / num4;
			zero = linePoint1 + lineVec1 * num7;
			zero2 = linePoint2 + lineVec2 * num8;
			return (success: true, point1: zero, point2: zero2);
		}
		return (success: false, point1: zero, point2: zero2);
	}

	public static Vector3 ClampCoords(Vector3 vectorToClamp, Vector3 min, Vector3 max)
	{
		for (int i = 0; i < 3; i++)
		{
			vectorToClamp[i] = Mathf.Clamp(vectorToClamp[i], min[i], max[i]);
		}
		return vectorToClamp;
	}

	public static Vector3 GetBarycentricCoordinates(Vector2 point, Vector2 triA, Vector2 triB, Vector2 triC)
	{
		float num = (triB.y - triC.y) * (triA.x - triC.x) + (triC.x - triB.x) * (triA.y - triC.y);
		float num2 = ((triB.y - triC.y) * (point.x - triC.x) + (triC.x - triB.x) * (point.y - triC.y)) / num;
		float num3 = ((triC.y - triA.y) * (point.x - triC.x) + (triA.x - triC.x) * (point.y - triC.y)) / num;
		float z = 1f - num2 - num3;
		return new Vector3(num2, num3, z);
	}

	public static bool IsPointInTriangle(Vector2 point, Vector2 triA, Vector2 triB, Vector2 triC)
	{
		return IsPointInTriangle(GetBarycentricCoordinates(point, triA, triB, triC));
	}

	public static bool IsPointInTriangle(Vector3 bary)
	{
		if (0f <= bary.x && bary.x <= 1f && 0f <= bary.y && bary.y <= 1f && 0f <= bary.z)
		{
			return bary.z <= 1f;
		}
		return false;
	}

	public static Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
	{
		Vector3 rhs = vPoint - vA;
		Vector3 normalized = (vB - vA).normalized;
		float num = Vector3.Distance(vA, vB);
		float num2 = Vector3.Dot(normalized, rhs);
		if (num2 <= 0f)
		{
			return vA;
		}
		if (num2 >= num)
		{
			return vB;
		}
		Vector3 vector = normalized * num2;
		return vA + vector;
	}

	public static Quaternion GetCamForwardRotation(Vector3 camForward, Vector3 camUp)
	{
		float num = Vector3.Dot(camUp, Vector3.up);
		float num2 = Vector3.Dot(camForward, Vector3.up);
		Vector3 vector = ((num > 0.5f) ? camForward : ((!(num2 > 0f)) ? camUp : (-camUp)));
		vector = Vector3.ProjectOnPlane(vector, Vector3.up).normalized;
		return Quaternion.LookRotation(vector, Vector3.up);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 GetPointVelocity(this Transform transform, Vector3 worldPosition, Vector3 velocity, Vector3 angularVelocity)
	{
		return GetPointVelocity(worldPosition - transform.position, velocity, angularVelocity);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector3 GetPointVelocity(Vector3 worldRelativePosition, Vector3 velocity, Vector3 angularVelocity)
	{
		return velocity + Vector3.Cross(angularVelocity, worldRelativePosition);
	}

	public static bool RayPlaneIntersection(Ray ray, Plane plane, out Vector3 intersection)
	{
		if (plane.Raycast(ray, out var enter))
		{
			intersection = ray.GetPoint(enter);
			return true;
		}
		intersection = ray.origin;
		return false;
	}

	public static bool RayPlaneIntersection(Vector3 rayOrigin, Vector3 rayDirection, Plane plane, out Vector3 intersection)
	{
		return RayPlaneIntersection(new Ray(rayOrigin, rayDirection), plane, out intersection);
	}

	public static bool RayPlaneIntersection(Ray ray, Vector3 planePoint, Vector3 planeNormal, out Vector3 intersection)
	{
		return RayPlaneIntersection(ray, new Plane(planeNormal, planePoint), out intersection);
	}

	public static bool RayPlaneIntersection(Vector3 rayOrigin, Vector3 rayDirection, Vector3 planePoint, Vector3 planeNormal, out Vector3 intersection)
	{
		return RayPlaneIntersection(new Ray(rayOrigin, rayDirection), new Plane(planeNormal, planePoint), out intersection);
	}

	public static bool RaySphereIntersection(Ray ray, Vector3 sphereCenter, float sphereRadius, out Vector3 intersection)
	{
		return RaySphereIntersection(ray.origin, ray.direction, sphereCenter, sphereRadius, out intersection);
	}

	public static bool RaySphereIntersection(Vector3 rayOrigin, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius, out Vector3 intersection)
	{
		Vector3 vector = rayOrigin - sphereCenter;
		float num = Vector3.Dot(vector, rayDirection);
		float num2 = Vector3.Dot(vector, vector) - sphereRadius * sphereRadius;
		if (num2 > 0f && num > 0f)
		{
			intersection = rayOrigin;
			return false;
		}
		float num3 = num * num - num2;
		if (num3 < 0f)
		{
			intersection = rayOrigin;
			return false;
		}
		float num4 = 0f - num - Mathf.Sqrt(num3);
		if (num4 < 0f)
		{
			num4 = 0f;
		}
		intersection = rayOrigin + num4 * rayDirection;
		return true;
	}
}
