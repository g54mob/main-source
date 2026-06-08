using UnityEngine;

namespace Kitchen
{
	public static class Vector3Extensions
	{
		public static float Chebyshev(this Vector3 vec)
		{
			return Mathf.Max(Mathf.Abs(vec.x), Mathf.Max(Mathf.Abs(vec.y), Mathf.Abs(vec.z)));
		}

		public static Vector3 ToWorld(this Vector2 vec)
		{
			return new Vector3(vec.x, 0f, vec.y);
		}

		public static Vector3 ToWorld(this Vector3 vec)
		{
			return new Vector3(vec.x, 0f, vec.y);
		}

		public static Vector3 ToFlat(this Vector3 vec)
		{
			return new Vector2(vec.x, vec.y);
		}

		public static Vector3 Rounded(this Vector3 vec)
		{
			return new Vector3(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y), Mathf.RoundToInt(vec.z));
		}

		public static Vector3 XZY(this Vector3 vec)
		{
			return new Vector3(vec.x, vec.z, vec.y);
		}

		public static bool IsSameTile(this Vector3 vec, Vector3 other)
		{
			return (vec.Rounded() - other.Rounded()).Chebyshev() < 0.1f;
		}

		public static bool ApproximatelyEqual(this Vector3 vec, Vector3 other)
		{
			if (Mathf.Abs(vec.x - other.x) < 0.001f && Mathf.Abs(vec.y - other.y) < 0.001f)
			{
				return Mathf.Abs(vec.z - other.z) < 0.001f;
			}
			return false;
		}
	}
}
