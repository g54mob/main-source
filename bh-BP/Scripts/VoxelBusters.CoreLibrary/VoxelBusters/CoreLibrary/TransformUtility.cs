using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class TransformUtility
	{
		public static Transform[] GetImmediateChildren(Transform transform)
		{
			return null;
		}

		public static T FindComponentInChildren<T>(GameObject gameObject, string name)
		{
			return default(T);
		}

		public static void RemoveAllChilds(this Transform parent)
		{
		}

		public static void RemoveChildren(this Transform parent)
		{
		}

		public static bool RemoveChild(this Transform parent, int index)
		{
			return false;
		}
	}
}
