using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	public static class MMGameObjectExtensions
	{
		private static List<Component> m_ComponentCache = new List<Component>();

		public static Component MMGetComponentNoAlloc(this GameObject @this, Type componentType)
		{
			@this.GetComponents(componentType, m_ComponentCache);
			Component result = ((m_ComponentCache.Count > 0) ? m_ComponentCache[0] : null);
			m_ComponentCache.Clear();
			return result;
		}

		public static T MMGetComponentNoAlloc<T>(this GameObject @this) where T : Component
		{
			@this.GetComponents(typeof(T), m_ComponentCache);
			Component obj = ((m_ComponentCache.Count > 0) ? m_ComponentCache[0] : null);
			m_ComponentCache.Clear();
			return obj as T;
		}

		public static T MMGetComponentAroundOrAdd<T>(this GameObject @this) where T : Component
		{
			T val = @this.GetComponentInChildren<T>(includeInactive: true);
			if (val == null)
			{
				val = @this.GetComponentInParent<T>();
			}
			if (val == null)
			{
				val = @this.AddComponent<T>();
			}
			return val;
		}

		public static T MMGetOrAddComponent<T>(this GameObject @this) where T : Component
		{
			T val = @this.GetComponent<T>();
			if (val == null)
			{
				val = @this.AddComponent<T>();
			}
			return val;
		}

		public static (T newComponent, bool createdNew) MMFindOrCreateObjectOfType<T>(this GameObject @this, string newObjectName, Transform parent, bool forceNewCreation = false) where T : Component
		{
			T val = (T)UnityEngine.Object.FindAnyObjectByType(typeof(T));
			if (val == null || forceNewCreation)
			{
				GameObject gameObject = new GameObject(newObjectName);
				gameObject.transform.SetParent(parent);
				return (newComponent: gameObject.AddComponent<T>(), createdNew: true);
			}
			return (newComponent: val, createdNew: false);
		}

		public static T MMInstantiateDisabled<T>(T originalObject, Transform parent = null, bool worldPositionStays = false) where T : UnityEngine.Object
		{
			if (!MMGetActiveState(originalObject))
			{
				return UnityEngine.Object.Instantiate(originalObject, parent, worldPositionStays);
			}
			(GameObject coreObject, Transform newObjectTransform) tuple = MMCreateDisabledObject(parent);
			GameObject item = tuple.coreObject;
			Transform item2 = tuple.newObjectTransform;
			T val = UnityEngine.Object.Instantiate(originalObject, item2, worldPositionStays);
			MMSetActiveState(val, newState: false);
			MMSetParent(val, parent, worldPositionStays);
			UnityEngine.Object.Destroy(item);
			return val;
		}

		public static T MMInstantiateDisabled<T>(T originalObject, Vector3 position, Quaternion rotation, Transform parent = null) where T : UnityEngine.Object
		{
			if (!MMGetActiveState(originalObject))
			{
				return UnityEngine.Object.Instantiate(originalObject, position, rotation, parent);
			}
			(GameObject coreObject, Transform newObjectTransform) tuple = MMCreateDisabledObject(parent);
			GameObject item = tuple.coreObject;
			Transform item2 = tuple.newObjectTransform;
			T val = UnityEngine.Object.Instantiate(originalObject, position, rotation, item2);
			MMSetActiveState(val, newState: false);
			MMSetParent(val, parent, worldPositionStays: false);
			UnityEngine.Object.Destroy(item);
			return val;
		}

		private static (GameObject coreObject, Transform newObjectTransform) MMCreateDisabledObject(Transform parent = null)
		{
			GameObject gameObject = new GameObject(string.Empty);
			gameObject.SetActive(value: false);
			Transform transform = gameObject.transform;
			transform.SetParent(parent);
			return (coreObject: gameObject, newObjectTransform: transform);
		}

		private static bool MMGetActiveState<T>(T targetObject) where T : UnityEngine.Object
		{
			if (!(targetObject is GameObject gameObject))
			{
				if (targetObject is Component component)
				{
					return component.gameObject.activeSelf;
				}
				return false;
			}
			return gameObject.activeSelf;
		}

		private static void MMSetActiveState<T>(T targetObject, bool newState) where T : UnityEngine.Object
		{
			if (!(targetObject is GameObject gameObject))
			{
				if (targetObject is Component component)
				{
					component.gameObject.SetActive(newState);
				}
			}
			else
			{
				gameObject.SetActive(newState);
			}
		}

		private static void MMSetParent<T>(T targetObject, Transform parent, bool worldPositionStays) where T : UnityEngine.Object
		{
			if (!(targetObject is GameObject gameObject))
			{
				if (targetObject is Component component)
				{
					component.transform.SetParent(parent, worldPositionStays);
				}
			}
			else
			{
				gameObject.transform.SetParent(parent, worldPositionStays);
			}
		}
	}
}
