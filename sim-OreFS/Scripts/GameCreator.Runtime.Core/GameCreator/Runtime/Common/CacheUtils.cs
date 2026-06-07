using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
	public static class CacheUtils
	{
		private class Cache
		{
			public readonly GameObject reference;

			public readonly Dictionary<Type, Component> components;

			public Cache(GameObject reference)
			{
				components = new Dictionary<Type, Component>();
				this.reference = reference;
			}
		}

		private static readonly Dictionary<int, Cache> CACHE = new Dictionary<int, Cache>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnSubsystemsInit()
		{
			CACHE.Clear();
			SceneManager.sceneUnloaded += delegate
			{
				Prune();
			};
		}

		public static T Get<T>(this Component component) where T : Component
		{
			return component.Get(typeof(T)) as T;
		}

		public static T Get<T>(this GameObject gameObject) where T : Component
		{
			return gameObject.Get(typeof(T)) as T;
		}

		public static Component Get(this Component component, Type type)
		{
			if (!(component != null))
			{
				return null;
			}
			return component.gameObject.Get(type);
		}

		public static Component Get(this GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			int instanceID = gameObject.GetInstanceID();
			if (!CACHE.TryGetValue(instanceID, out var value))
			{
				value = new Cache(gameObject);
				CACHE[instanceID] = value;
			}
			if (!value.components.TryGetValue(type, out var value2))
			{
				value2 = gameObject.GetComponent(type);
				if (value2 != null)
				{
					value.components[type] = value2;
					CACHE[instanceID] = value;
				}
			}
			return value2;
		}

		public static T Add<T>(this Component component) where T : Component
		{
			if (!(component != null))
			{
				return null;
			}
			return component.gameObject.Add<T>();
		}

		public static T Add<T>(this GameObject gameObject) where T : Component
		{
			return gameObject.Add(typeof(T)) as T;
		}

		public static Component Add(this Component component, Type type)
		{
			if (!(component != null))
			{
				return null;
			}
			return component.gameObject.Add(type);
		}

		public static Component Add(this GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			int instanceID = gameObject.GetInstanceID();
			if (!CACHE.TryGetValue(instanceID, out var value))
			{
				value = new Cache(gameObject);
				CACHE[instanceID] = value;
			}
			Component component = gameObject.AddComponent(type);
			value.components[type] = component;
			return component;
		}

		public static T Require<T>(this Component component) where T : Component
		{
			if (!(component != null))
			{
				return null;
			}
			return component.gameObject.Require<T>();
		}

		public static T Require<T>(this GameObject gameObject) where T : Component
		{
			return gameObject.Require(typeof(T)) as T;
		}

		public static Component Require(this Component component, Type type)
		{
			if (!(component != null))
			{
				return null;
			}
			return component.gameObject.Require(type);
		}

		public static Component Require(this GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			int instanceID = gameObject.GetInstanceID();
			if (!CACHE.TryGetValue(instanceID, out var value))
			{
				value = new Cache(gameObject);
				CACHE[instanceID] = value;
			}
			Component component = gameObject.Get(type);
			if (component != null)
			{
				return component;
			}
			component = gameObject.AddComponent(type);
			value.components[type] = component;
			return component;
		}

		public static void Prune()
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, Cache> item in CACHE)
			{
				if (item.Value.reference == null)
				{
					list.Add(item.Key);
				}
			}
			foreach (int item2 in list)
			{
				CACHE.Remove(item2);
			}
		}
	}
}
