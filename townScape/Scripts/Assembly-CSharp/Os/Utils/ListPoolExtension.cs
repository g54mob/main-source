using System.Collections.Generic;
using UnityEngine;

namespace Os.Utils
{
	public static class ListPoolExtension
	{
		public static void ReturnToPool<T>(this List<T> list)
		{
		}

		public static List<T> GetListOfComponentsInChildren<T>(this GameObject gameObject) where T : Component
		{
			return null;
		}

		public static T Pop<T>(this List<T> list, int index)
		{
			return default(T);
		}
	}
}
