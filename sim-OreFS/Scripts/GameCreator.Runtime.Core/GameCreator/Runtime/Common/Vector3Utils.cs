using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class Vector3Utils
	{
		public static Vector3 OnSegment(this Vector3 point, Vector3 pointA, Vector3 pointB)
		{
			Vector3 vector = pointB - pointA;
			float magnitude = vector.magnitude;
			if (magnitude < float.Epsilon)
			{
				return pointA;
			}
			vector.Normalize();
			float value = Vector3.Dot(point - pointA, vector);
			value = Mathf.Clamp(value, 0f, magnitude);
			return pointA + vector * value;
		}

		public static Vector3 PointOnVector(this Vector3 point, Vector3 direction)
		{
			return Vector3.Dot(point, direction) / direction.magnitude * direction;
		}

		public static Vector3 ProjectPointOntoRay(this Vector3 point, Ray ray)
		{
			Vector3 lhs = point - ray.origin;
			float sqrMagnitude = ray.direction.sqrMagnitude;
			if (sqrMagnitude < float.Epsilon)
			{
				return ray.origin;
			}
			float num = Mathf.Max(0f, Vector3.Dot(lhs, ray.direction) / sqrMagnitude);
			return ray.origin + num * ray.direction;
		}

		public static Vector3 LerpDirections(Vector3 directionA, Vector3 directionB, float t)
		{
			if (directionA == directionB)
			{
				return directionA;
			}
			Quaternion a = Quaternion.LookRotation(directionA.normalized);
			Quaternion b = Quaternion.LookRotation(directionB.normalized);
			return Quaternion.Slerp(a, b, t) * Vector3.forward;
		}

		public static float InverseLerp(Vector3 a, Vector3 b, Vector3 position)
		{
			Vector3 onNormal = b - a;
			if (onNormal.magnitude <= float.Epsilon)
			{
				return 0f;
			}
			return Mathf.Clamp01(Vector3.Project(position - a, onNormal).magnitude / onNormal.magnitude);
		}

		public static Vector3 Lerp(Vector3 a, Vector3 b, Vector3 c, float t)
		{
			if (!(t <= 0.5f))
			{
				return Vector3.Lerp(b, c, t * 2f - 1f);
			}
			return Vector3.Lerp(a, b, t * 2f);
		}
	}
}
