using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public static class DTMath
	{
		public static Vector3 ParallelTransportFrame(Vector3 up, Vector3 tan0, Vector3 tan1)
		{
			return default(Vector3);
		}

		public static Vector3 LeftTan(ref Vector3 tan, ref Vector3 up)
		{
			return default(Vector3);
		}

		public static Vector3 RightTan(ref Vector3 tan, ref Vector3 up)
		{
			return default(Vector3);
		}

		public static float Repeat(float t, float length)
		{
			return 0f;
		}

		public static double FixNaN(double v)
		{
			return 0.0;
		}

		public static float FixNaN(float v)
		{
			return 0f;
		}

		public static Vector2 FixNaN(Vector2 v)
		{
			return default(Vector2);
		}

		public static Vector3 FixNaN(Vector3 v)
		{
			return default(Vector3);
		}

		public static float MapValue(float min, float max, float value, float vMin = -1f, float vMax = 1f)
		{
			return 0f;
		}

		public static float SnapPrecision(float value, int decimals)
		{
			return 0f;
		}

		public static Vector2 SnapPrecision(Vector2 value, int decimals)
		{
			return default(Vector2);
		}

		public static Vector3 SnapPrecision(Vector3 value, int decimals)
		{
			return default(Vector3);
		}

		public static float LinePointDistanceSqr(Vector3 l1, Vector3 l2, Vector3 p, out float frag)
		{
			frag = default(float);
			return 0f;
		}

		public static bool RayLineSegmentIntersection(Vector2 r0, Vector2 dir, Vector2 l1, Vector2 l2, out Vector2 hit, out float frag)
		{
			hit = default(Vector2);
			frag = default(float);
			return false;
		}

		public static bool ShortestIntersectionLine(Vector3 line1A, Vector3 line1B, Vector3 line2A, Vector3 line2B, out Vector3 resultSegmentA, out Vector3 resultSegmentB)
		{
			resultSegmentA = default(Vector3);
			resultSegmentB = default(Vector3);
			return false;
		}

		public static bool LineLineIntersection(Vector3 line1A, Vector3 line1B, Vector3 line2A, Vector3 line2B, out Vector3 hitPoint)
		{
			hitPoint = default(Vector3);
			return false;
		}

		public static bool LineLineIntersect(Vector2 line1A, Vector2 line1B, Vector2 line2A, Vector2 line2B, out Vector2 hitPoint, bool segmentOnly = true)
		{
			hitPoint = default(Vector2);
			return false;
		}

		public static bool PointInsideTriangle(Vector3 A, Vector3 B, Vector3 C, Vector3 p, out float ac, out float ab, bool edgesAllowed)
		{
			ac = default(float);
			ab = default(float);
			return false;
		}
	}
}
