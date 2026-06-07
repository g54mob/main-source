using System;
using UnityEngine;

namespace HighlightPlus
{
	public class Misc
	{
		public static Vector2 vector2Zero;

		public static Vector2 vector2One;

		public static Vector3 vector3Zero;

		public static Vector3 vector3Max;

		public static Vector3 vector3Min;

		public static T FindObjectOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return null;
		}

		public static UnityEngine.Object[] FindObjectsOfType(Type type, bool includeInactive = false)
		{
			return null;
		}

		public static T[] FindObjectsOfType<T>(bool includeInactive = false) where T : UnityEngine.Object
		{
			return null;
		}
	}
}
