using System;
using System.Collections.Generic;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class ComponentExtensions
	{
		public static void GetComponentsInDirectChildren<T>(this Component parent, bool includeInactive, List<T> results) where T : Component
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			Transform transform = parent.transform;
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if ((includeInactive || child.gameObject.activeInHierarchy) && child.TryGetComponent<T>(out var component))
				{
					results.Add(component);
				}
			}
		}

		public static T[] GetComponentsInDirectChildren<T>(this Component parent, bool includeInactive = false) where T : Component
		{
			List<T> value;
			using (CollectionPool<List<T>, T>.Get(out value))
			{
				parent.GetComponentsInDirectChildren(includeInactive, value);
				return value.ToArray();
			}
		}
	}
}
