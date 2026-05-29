using System.Collections.Generic;
using UnityEngine;

namespace GameKit.Utilities
{
	public static class Objects
	{
		public static bool IsDestroyed(this GameObject gameObject)
		{
			return false;
		}

		public static List<T> FindAllObjectsOfType<T>(bool activeSceneOnly = true, bool requireSceneLoaded = false, bool includeDDOL = true, bool includeInactive = true)
		{
			return null;
		}
	}
}
