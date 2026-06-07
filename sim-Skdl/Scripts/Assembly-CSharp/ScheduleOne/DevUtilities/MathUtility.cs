using UnityEngine;

namespace ScheduleOne.DevUtilities
{
	public static class MathUtility
	{
		public static bool PointInsideCube(Vector3 point, Vector3 center, Vector3 halfExtents)
		{
			return false;
		}

		public static bool PointInsideRectangle(Vector2 point, Vector2 center, Vector2 halfExtents)
		{
			return false;
		}

		public static Vector2 ClosestPointOnSegment(Vector2 point, Vector2 a, Vector2 b)
		{
			return default(Vector2);
		}

		public static Vector3 ClosestPointOnSegment(Vector3 point, Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}

		public static float GetNormalizedPositionAlongSegment(Vector2 a, Vector2 b, Vector2 c)
		{
			return 0f;
		}

		public static float GetNormalizedPositionAlongSegment(Vector3 a, Vector3 b, Vector3 c)
		{
			return 0f;
		}

		public static int GetWrappedIndex(int index, int change, int size)
		{
			return 0;
		}

		public static bool BetweenValues(float value, float min, float max, bool maxInclusive = false, bool minInclusive = false)
		{
			return false;
		}

		public static float Normalise(float value, float min, float max)
		{
			return 0f;
		}

		public static float SqrDistance(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		public static float InverseDistance01(Vector3 a, Vector3 b, float minDist, float maxDist)
		{
			return 0f;
		}

		public static float InverseDistance01(float sqrDist, float minDist, float maxDist)
		{
			return 0f;
		}

		public static bool NearlyEqual(float a, float b, float tolerance)
		{
			return false;
		}

		public static float LogLerp(float a, float b, float t)
		{
			return 0f;
		}

		public static Plane CreatePlaneFromPoints(Vector3 p1, Vector3 p2, Vector3 p3)
		{
			return default(Plane);
		}

		public static Vector3 ClosestPointOnPlane(in Plane plane, in Vector3 point)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPointOnPlane(in Vector3 normal, float distance, in Vector3 point)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPointOnQuad(Vector3 point, Vector3 origin, Vector3 axisU, Vector3 axisV, float halfU, float halfV)
		{
			return default(Vector3);
		}
	}
}
