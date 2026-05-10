using UnityEngine;

namespace PG
{
	public static class TransformExtensions
	{
		public static T GetSafe<T>(this T[] array, int index)
		{
			return default(T);
		}

		public static void SetGlobalX(this Transform transform, float x)
		{
		}

		public static void SetGlobalY(this Transform transform, float y)
		{
		}

		public static void SetGlobalZ(this Transform transform, float z)
		{
		}

		public static void SetLocalX(this Transform transform, float x)
		{
		}

		public static void SetLocalY(this Transform transform, float y)
		{
		}

		public static void SetLocalZ(this Transform transform, float z)
		{
		}

		public static void SetAnchoredX(this RectTransform transform, float x)
		{
		}

		public static void SetAnchoredY(this RectTransform transform, float y)
		{
		}

		public static void SetAnchoredZ(this RectTransform transform, float z)
		{
		}

		public static bool CheckParent(this Transform tr, Transform parent)
		{
			return false;
		}

		public static T GetTopmostParentComponent<T>(this Transform tr) where T : Component
		{
			return null;
		}
	}
}
