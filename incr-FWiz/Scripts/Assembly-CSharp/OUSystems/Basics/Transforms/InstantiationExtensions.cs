using System;
using System.Collections.Generic;
using UnityEngine;

namespace OUSystems.Basics.Transforms
{
	public static class InstantiationExtensions
	{
		public static List<T> InstantiateList<T, V>(this T prefab, IEnumerable<V> list, Transform parent, Action<T, V> apply = null) where T : MonoBehaviour
		{
			return null;
		}
	}
}
