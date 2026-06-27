using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure
{
	public static class ZenjectInstallerExtension
	{
		private static readonly List<Component> ComponentsPool = new List<Component>(50);

		public static GameObject InstantiateAndQueueForInject(this DiContainer container, GameObject prefab, Transform parent = null)
		{
			GameObject gameObject = ((parent != null) ? UnityEngine.Object.Instantiate(prefab, parent) : UnityEngine.Object.Instantiate(prefab, container.DefaultParent));
			container.QueueAllComponentsForInject(gameObject);
			return gameObject;
		}

		public static GameObject InstantiateAndQueueForInject(this DiContainer container, GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			if (parent == null)
			{
				parent = container.DefaultParent;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, position, rotation, parent);
			container.QueueAllComponentsForInject(gameObject);
			return gameObject;
		}

		public static void QueueAllComponentsForInject(this DiContainer container, GameObject instance)
		{
			instance.GetComponentsInChildren(includeInactive: true, ComponentsPool);
			foreach (Component item in ComponentsPool)
			{
				if ((bool)item)
				{
					container.QueueForInject(item);
				}
				else
				{
					Debug.LogError("[Zenject] GameObject " + instance.name + " contains empty/corrupted script", instance);
				}
			}
		}

		public static void FindAndBindInterfacesAndSelfTo<T>(this DiContainer container) where T : MonoBehaviour
		{
			T[] array = UnityEngine.Object.FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			foreach (T instance in array)
			{
				container.BindInterfacesAndSelfTo<T>().FromInstance(instance);
			}
		}

		public static void FindAndBindInterfacesAndSelfToAsCached<T>(this DiContainer container) where T : MonoBehaviour
		{
			T[] array = UnityEngine.Object.FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			foreach (T instance in array)
			{
				container.BindInterfacesAndSelfTo<T>().FromInstance(instance).AsCached();
			}
		}

		public static void FindAndBindInterfacesAndSelfToAsSingle<T>(this DiContainer container) where T : MonoBehaviour
		{
			T val = UnityEngine.Object.FindAnyObjectByType<T>(FindObjectsInactive.Include);
			if (val == null)
			{
				Debug.LogError("<color=red>Failed to find any instance of " + typeof(T).Name + "</color>");
			}
			else
			{
				container.BindInterfacesAndSelfTo<T>().FromInstance(val).AsSingle();
			}
		}

		public static void FindAndEnqueueForInject<T>(this DiContainer container) where T : MonoBehaviour
		{
			T[] array = UnityEngine.Object.FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			foreach (T instance in array)
			{
				container.QueueForInject(instance);
			}
		}

		public static IdScopeConcreteIdArgConditionCopyNonLazyBinder BindInstanceAndEnqueueForInject<T>(this DiContainer container, T instance) where T : MonoBehaviour
		{
			IdScopeConcreteIdArgConditionCopyNonLazyBinder result = container.BindInstance(instance);
			container.QueueForInject(instance);
			return result;
		}

		[Obsolete("Not obvious extension name.")]
		public static void FullBindFromNewGameObject<T>(this DiContainer container, GameObject prefab) where T : MonoBehaviour
		{
			T component = container.InstantiateAndQueueForInject(prefab).GetComponent<T>();
			container.BindInterfacesAndSelfTo<T>().FromInstance(component).AsSingle()
				.NonLazy();
		}
	}
}
