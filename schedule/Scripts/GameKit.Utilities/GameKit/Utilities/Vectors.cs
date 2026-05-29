using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameKit.Utilities
{
	public static class Vectors
	{
		private static readonly Vector3 VECTOR3_ZERO;

		private const float FLOAT_EPSILON = 1E-05f;

		public static float GetRate(this Vector3 a, Vector3 goal, float duration, out float distance, uint interval = 1u)
		{
			distance = default(float);
			return 0f;
		}

		public static Vector3 Add(this Vector3 v3, Vector2 v2)
		{
			return default(Vector3);
		}

		public static Vector3 Subtract(this Vector3 v3, Vector2 v2)
		{
			return default(Vector3);
		}

		public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
		{
			return 0f;
		}

		public static bool Near(this Vector3 a, Vector3 b, float tolerance = 0.01f)
		{
			return false;
		}

		public static bool IsNan(this Vector3 source)
		{
			return false;
		}

		public static Vector3 Lerp3(Vector3 a, Vector3 b, Vector3 c, float percent)
		{
			return default(Vector3);
		}

		public static Vector3 Lerp3(Vector3[] vectors, float percent)
		{
			return default(Vector3);
		}

		public static Vector3 Multiply(this Vector3 src, Vector3 multiplier)
		{
			return default(Vector3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float FastDistance(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float FastSqrMagnitude(Vector3 vector)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 FastNormalize(Vector3 value)
		{
			return default(Vector3);
		}

		public static float GetRate(this Vector2 a, Vector2 goal, float duration, out float distance, uint interval = 1u)
		{
			distance = default(float);
			return 0f;
		}

		public static Vector2 Lerp3(Vector2 a, Vector2 b, Vector2 c, float percent)
		{
			return default(Vector2);
		}

		public static Vector2 Lerp2(Vector2[] vectors, float percent)
		{
			return default(Vector2);
		}

		public static Vector2 Multiply(this Vector2 src, Vector2 multiplier)
		{
			return default(Vector2);
		}
	}
}
