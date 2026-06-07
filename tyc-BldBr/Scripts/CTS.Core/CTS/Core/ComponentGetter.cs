using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Core
{
	public static class ComponentGetter
	{
		private static readonly Dictionary<Type, Component> _singletonCache = new Dictionary<Type, Component>();

		public static object GetComponent(MonoBehaviour target, EGetScope scope, Type type, bool isArray)
		{
			if (isArray)
			{
				return GetComponentArray(target, scope, type);
			}
			return GetComponentSingle(target, scope, type);
		}

		public static object GetComponentArray(MonoBehaviour target, EGetScope scope, Type type)
		{
			return scope switch
			{
				EGetScope.Object => GetComponentArrayObject(target, type), 
				EGetScope.Parent => GetComponentArrayParent(target, type), 
				EGetScope.ParentExclusive => GetComponentArrayParentExclusive(target, type), 
				EGetScope.Children => GetComponentArrayChildren(target, type), 
				EGetScope.ChildrenExclusive => GetComponentArrayChildrenExclusive(target, type), 
				EGetScope.Singleton => GetComponentArraySingleton(type), 
				_ => throw new ArgumentOutOfRangeException("scope", scope, null), 
			};
		}

		public static object GetComponentSingle(MonoBehaviour target, EGetScope scope, Type type)
		{
			return scope switch
			{
				EGetScope.Object => target.GetComponent(type), 
				EGetScope.Parent => target.GetComponentInParent(type, includeInactive: true), 
				EGetScope.ParentExclusive => GetComponentSingleParentExclusive(target, type), 
				EGetScope.Children => target.GetComponentInChildren(type, includeInactive: true), 
				EGetScope.ChildrenExclusive => GetComponentSingleChildrenExclusive(target, type), 
				EGetScope.Singleton => GetComponentSingleSingleton(type), 
				_ => throw new ArgumentOutOfRangeException("scope", scope, null), 
			};
		}

		public static object GetComponentArrayObject(MonoBehaviour target, Type type)
		{
			return ComponentArrayToObject(target.GetComponents(type), type);
		}

		public static object GetComponentArrayParent(MonoBehaviour target, Type type)
		{
			return ComponentArrayToObject(target.GetComponentsInParent(type, includeInactive: true), type);
		}

		public static object GetComponentArrayParentExclusive(MonoBehaviour target, Type type)
		{
			Component[] array = ((!(target.transform.parent == null)) ? target.transform.parent.GetComponentsInParent(type, includeInactive: true) : Array.Empty<Component>());
			return ComponentArrayToObject(array, type);
		}

		public static object GetComponentArrayChildren(MonoBehaviour target, Type type)
		{
			return ComponentArrayToObject(target.GetComponentsInChildren(type, includeInactive: true), type);
		}

		public static object GetComponentArrayChildrenExclusive(MonoBehaviour target, Type type)
		{
			Component[] array;
			if (target.transform.childCount == 0)
			{
				array = Array.Empty<Component>();
			}
			else
			{
				List<Component> list = new List<Component>();
				foreach (Transform child in target.transform.GetChildren())
				{
					list.AddRange(child.GetComponentsInChildren(type, includeInactive: true));
				}
				array = list.ToArray();
			}
			return ComponentArrayToObject(array, type);
		}

		public static object GetComponentArraySingleton(Type type)
		{
			return ObjectArrayToObject(UnityEngine.Object.FindObjectsByType(type, FindObjectsSortMode.None), type);
		}

		public static object GetComponentSingleSingleton(Type type)
		{
			if (_singletonCache.TryGetValue(type, out var value) && (bool)value)
			{
				return value;
			}
			value = (Component)UnityEngine.Object.FindObjectOfType(type, includeInactive: true);
			if (!value)
			{
				return null;
			}
			_singletonCache[type] = value;
			return value;
		}

		public static object GetComponentSingleParentExclusive(MonoBehaviour target, Type type)
		{
			if (target.transform.parent == null)
			{
				return null;
			}
			return target.transform.parent.GetComponentInParent(type, includeInactive: true);
		}

		public static object GetComponentSingleChildrenExclusive(MonoBehaviour target, Type type)
		{
			if (target.transform.childCount == 0)
			{
				return null;
			}
			foreach (Transform child in target.transform.GetChildren())
			{
				Component componentInChildren = child.GetComponentInChildren(type, includeInactive: true);
				if ((bool)componentInChildren)
				{
					return componentInChildren;
				}
			}
			return null;
		}

		private static object ComponentArrayToObject(Component[] array, Type type)
		{
			Array array2 = Array.CreateInstance(type, array.Length);
			for (int i = 0; i < array2.Length; i++)
			{
				array2.SetValue(array[i], i);
			}
			return array2;
		}

		private static object ObjectArrayToObject(UnityEngine.Object[] array, Type type)
		{
			Array array2 = Array.CreateInstance(type, array.Length);
			for (int i = 0; i < array2.Length; i++)
			{
				array2.SetValue(array[i], i);
			}
			return array2;
		}
	}
}
