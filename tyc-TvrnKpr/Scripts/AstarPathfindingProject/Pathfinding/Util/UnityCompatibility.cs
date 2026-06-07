using UnityEngine;

namespace Pathfinding.Util
{
	public static class UnityCompatibility
	{
		public static T[] FindObjectsByTypeSorted<T>() where T : Object
		{
			return null;
		}

		public static T[] FindObjectsByTypeUnsorted<T>() where T : Object
		{
			return null;
		}

		public static T[] FindObjectsByTypeUnsortedWithInactive<T>() where T : Object
		{
			return null;
		}

		public static T FindAnyObjectByType<T>() where T : Object
		{
			return null;
		}
	}
}
