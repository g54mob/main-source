using UnityEngine;

namespace Kitchen
{
	public static class TransformExtensions
	{
		public static void Reset(this Transform t)
		{
			t.localPosition = Vector3.zero;
			t.localScale = Vector3.one;
			t.localRotation = Quaternion.identity;
		}

		public static void ParentTo(this Transform t, Transform parent)
		{
			t.parent = parent;
			t.Reset();
		}

		public static void ParentTo(this Transform t, GameObject parent)
		{
			t.ParentTo(parent.transform);
		}

		public static void RemoveChildren(this Transform t)
		{
			foreach (object item in t)
			{
				if (item is Transform transform)
				{
					Object.Destroy(transform.gameObject);
				}
			}
		}
	}
}
