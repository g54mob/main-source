using System;
using UnityEngine;

namespace TH20
{
	public static class TransformEx
	{
		public static int FindIndex(this Transform transform, Func<Transform, bool> func)
		{
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				if (func(transform.GetChild(i)))
				{
					return i;
				}
			}
			return -1;
		}

		public static void IterateChildren(this Transform root, Action<Transform> callback)
		{
			foreach (Transform item in root)
			{
				callback.InvokeSafe(item);
				item.IterateChildren(callback);
			}
		}
	}
}
