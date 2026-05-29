using UnityEngine;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class Vector3Ext
	{
		public static float AngleSigned(this Vector3 a, Vector3 b, Vector3 normal)
		{
			return 0f;
		}

		public static Vector3 RotateAround(this Vector3 point, Vector3 origin, Quaternion rotation)
		{
			return default(Vector3);
		}

		public static Vector2 ToVector2(this Vector3 v)
		{
			return default(Vector2);
		}

		public static bool Approximately(this Vector3 v1, Vector3 v2)
		{
			return false;
		}

		public static bool NotApproximately(this Vector3 v1, Vector3 v2)
		{
			return false;
		}
	}
}
