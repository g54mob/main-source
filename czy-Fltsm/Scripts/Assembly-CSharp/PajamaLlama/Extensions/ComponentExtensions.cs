using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Extensions
{
	public static class ComponentExtensions
	{
		public static T GetOrAddComponent<T>(this Component component) where T : Component
		{
			T component2 = component.GetComponent<T>();
			if ((bool)component2)
			{
				return component2;
			}
			return component.gameObject.AddComponent<T>();
		}

		public static bool TryGetComponentInParent<T>(this Component component, out T componentInParent) where T : Component
		{
			componentInParent = component.GetComponentInParent<T>();
			return componentInParent != null;
		}

		public static bool TryGetComponentInParent<T>(this GameObject gameObject, out T componentInParent) where T : Component
		{
			componentInParent = gameObject.GetComponentInParent<T>();
			return componentInParent != null;
		}

		public static bool TryGetComponentInChildren<T>(this Component component, out T componentInChildren)
		{
			componentInChildren = component.GetComponentInChildren<T>();
			return componentInChildren != null;
		}

		public static bool TryGetComponentInChildren<T>(this GameObject gameObject, out T componentInChildren) where T : Component
		{
			componentInChildren = gameObject.GetComponentInChildren<T>();
			return componentInChildren != null;
		}

		public static string HierarchyPathToString(this Component component)
		{
			return component.transform.HierarchyPathToString();
		}

		public static bool TryReturnClosest<T>(this List<T> components, out T closestComponent, Vector3 position, float range) where T : Component
		{
			float num = range * range;
			closestComponent = null;
			foreach (T component in components)
			{
				float num2 = position.DistanceToSquared(component.transform.position);
				if (num2 < num)
				{
					num = num2;
					closestComponent = component;
				}
			}
			return closestComponent;
		}
	}
}
