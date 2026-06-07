using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	public static class GameObjectExt
	{
		public static bool IsChildOf(this GameObject rThis, GameObject rParent)
		{
			return false;
		}

		public static object GetComponentInParents(this GameObject rThis, Type rType)
		{
			return null;
		}

		public static T GetComponentInParents<T>(this GameObject rThis) where T : Component
		{
			return null;
		}

		public static T GetCopyOf<T>(this Component rThis, T rOther) where T : Component
		{
			return null;
		}

		public static T GetOrAddComponent<T>(this Component rComponent) where T : Component
		{
			return null;
		}

		public static T GetOrAddComponent<T>(this GameObject rGameObject) where T : Component
		{
			return null;
		}
	}
}
