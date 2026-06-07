using UnityEngine;

namespace tripolygon.UModeler
{
	public class Comparer
	{
		public static bool IsEquivalent<T>(T v0, T v1)
		{
			if (typeof(T) == typeof(Vector3))
			{
				return IsEquivalent((Vector3)(object)v0, (Vector3)(object)v1);
			}
			if (typeof(T) == typeof(Vector2))
			{
				return IsEquivalent((Vector2)(object)v0, (Vector2)(object)v1);
			}
			if (typeof(T) == typeof(float))
			{
				return IsEquivalent((float)(object)v0, (float)(object)v1);
			}
			return false;
		}

		public static bool IsEquivalent(Vector3 v0, Vector3 v1)
		{
			return IsEquivalent(v0, v1, 0.0001f);
		}

		public static bool IsEquivalent(Vector3 v0, Vector3 v1, float kEpsilon)
		{
			if (Mathf.Abs(v0.x - v1.x) < kEpsilon && Mathf.Abs(v0.y - v1.y) < kEpsilon)
			{
				return Mathf.Abs(v0.z - v1.z) < kEpsilon;
			}
			return false;
		}

		public static bool IsEquivalent(Vector2 v0, Vector2 v1)
		{
			if (Mathf.Abs(v0.x - v1.x) < 0.0001f)
			{
				return Mathf.Abs(v0.y - v1.y) < 0.0001f;
			}
			return false;
		}

		public static bool IsEquivalent(float v0, float v1)
		{
			return IsEquivalent(v0, v1, 0.0001f);
		}

		public static bool IsEquivalent(float v0, float v1, float epsilon)
		{
			return Mathf.Abs(v0 - v1) < epsilon;
		}

		public static bool IsEquivalent(Color color0, Color color1)
		{
			if (IsEquivalent(color0.r, color1.r) && IsEquivalent(color0.g, color1.g) && IsEquivalent(color0.b, color1.b))
			{
				return IsEquivalent(color0.a, color1.a);
			}
			return false;
		}
	}
}
