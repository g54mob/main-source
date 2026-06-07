using UnityEngine;

namespace ParadoxNotion
{
	public static class CurveUtils
	{
		private const float POS_CHECK_RES = 100f;

		private const float POS_CHECK_DISTANCE = 10f;

		public static Vector2 GetPosAlongCurve(Vector2 from, Vector2 to, Vector2 fromTangent, Vector2 toTangent, float t)
		{
			return default(Vector2);
		}

		public static bool IsPosAlongCurve(Vector2 from, Vector2 to, Vector2 fromTangent, Vector2 toTangent, Vector2 targetPosition)
		{
			return false;
		}

		public static bool IsPosAlongCurve(Vector2 from, Vector2 to, Vector2 fromTangent, Vector2 toTangent, Vector2 targetPosition, out float norm)
		{
			norm = default(float);
			return false;
		}

		public static void ResolveTangents(Vector2 from, Vector2 to, float rigidMlt, PlanarDirection direction, out Vector2 fromTangent, out Vector2 toTangent)
		{
			fromTangent = default(Vector2);
			toTangent = default(Vector2);
		}

		public static void ResolveTangents(Vector2 from, Vector2 to, Rect fromRect, Rect toRect, float rigidMlt, PlanarDirection direction, out Vector2 fromTangent, out Vector2 toTangent)
		{
			fromTangent = default(Vector2);
			toTangent = default(Vector2);
		}
	}
}
