using System;
using UnityEngine;

namespace HighlightPlus
{
	public class Misc
	{
		public static T FindObjectOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindAnyObjectByType<T>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude);
		}

		public static UnityEngine.Object[] FindObjectsOfType(Type type, bool includeInactive = false)
		{
			return UnityEngine.Object.FindObjectsByType(type, includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None);
		}

		public static T[] FindObjectsOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindObjectsByType<T>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None);
		}
	}
}
