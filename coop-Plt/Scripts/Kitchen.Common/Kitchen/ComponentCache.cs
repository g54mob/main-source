using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class ComponentCache
	{
		private Transform Transform;

		private Dictionary<Type, MonoBehaviour> CachedComponents = new Dictionary<Type, MonoBehaviour>();

		public ComponentCache(Transform transform)
		{
			Transform = transform;
		}

		public T Get<T>() where T : MonoBehaviour
		{
			if (TryGet<T>(out var component))
			{
				return component;
			}
			T val = Transform.GetComponent<T>();
			if (val == null)
			{
				val = Transform.GetComponentInChildren<T>(includeInactive: true);
			}
			CachedComponents[typeof(T)] = val;
			return val;
		}

		public bool TryGet<T>(out T component) where T : MonoBehaviour
		{
			Type typeFromHandle = typeof(T);
			component = null;
			if (!CachedComponents.TryGetValue(typeFromHandle, out var value))
			{
				return false;
			}
			component = (T)value;
			return true;
		}

		public void Add<T>(T component) where T : MonoBehaviour
		{
			CachedComponents[typeof(T)] = component;
		}

		public void Clear()
		{
			CachedComponents.Clear();
		}
	}
}
