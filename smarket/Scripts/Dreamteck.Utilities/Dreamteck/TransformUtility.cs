using UnityEngine;

namespace Dreamteck
{
	public static class TransformUtility
	{
		public static Vector3 GetPosition(Matrix4x4 m)
		{
			return default(Vector3);
		}

		public static Quaternion GetRotation(Matrix4x4 m)
		{
			return default(Quaternion);
		}

		public static Vector3 GetScale(Matrix4x4 m)
		{
			return default(Vector3);
		}

		public static void SetPosition(ref Matrix4x4 m, ref Vector3 p)
		{
		}

		public static void GetChildCount(Transform parent, ref int count)
		{
		}

		public static void MergeBoundsRecursively(this Transform rootParent, Transform tr, ref Bounds bounds, string nameToIgnore = null)
		{
		}

		public static bool IsParent(Transform child, Transform parent)
		{
			return false;
		}
	}
}
