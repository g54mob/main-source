using System;
using System.Collections.Generic;
using UnityEngine;

namespace ParadoxNotion
{
	public static class ObjectUtils
	{
		public static bool AnyEquals(object a, object b)
		{
			return false;
		}

		public static List<T> Shuffle<T>(this List<T> list)
		{
			return null;
		}

		public static bool Is<T>(this object o, out T result)
		{
			result = default(T);
			return false;
		}

		public static T GetAddComponent<T>(this GameObject gameObject)
		{
			return default(T);
		}

		public static Component TransformToType(this Component current, Type type)
		{
			return null;
		}

		public static IEnumerable<GameObject> FindGameObjectsWithinLayerMask(LayerMask mask, GameObject exclude = null)
		{
			return null;
		}

		public static bool IsInLayerMask(this GameObject gameObject, LayerMask mask)
		{
			return false;
		}
	}
}
