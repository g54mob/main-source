using UnityEngine;

namespace Pathfinding.Util
{
	public static class UnityCompatibility
	{
		public static T[] FindObjectsByTypeSorted<T>() where T : Object
		{
			return Object.FindObjectsByType<T>(FindObjectsSortMode.InstanceID);
		}

		public static T[] FindObjectsByTypeUnsorted<T>() where T : Object
		{
			return Object.FindObjectsByType<T>(FindObjectsSortMode.None);
		}

		public static T[] FindObjectsByTypeUnsortedWithInactive<T>() where T : Object
		{
			return Object.FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
		}

		public static T FindAnyObjectByType<T>() where T : Object
		{
			return Object.FindAnyObjectByType<T>();
		}
	}
}
