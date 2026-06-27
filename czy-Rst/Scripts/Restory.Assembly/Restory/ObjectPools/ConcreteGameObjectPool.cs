using System;
using System.Collections.Generic;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.ObjectPools
{
	public class ConcreteGameObjectPool : IDisposable
	{
		private readonly string nameContainer;

		private readonly GameObject prefab;

		private readonly Queue<PoolableEntity> pool = new Queue<PoolableEntity>();

		private readonly HashSet<PoolableEntity> pooledEntities = new HashSet<PoolableEntity>();

		private readonly bool disposePoolContainer = true;

		private Transform poolContainer;

		private readonly ApplicationQuitStartObserver applicationQuitStartObserver;

		private readonly DiContainer diContainer;

		public ConcreteGameObjectPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: this(diContainer, applicationQuitStartObserver, prefab, prefab.name + "PoolContainer")
		{
		}

		public ConcreteGameObjectPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab, string nameContainer)
		{
			this.diContainer = diContainer;
			this.applicationQuitStartObserver = applicationQuitStartObserver;
			this.prefab = prefab;
			this.nameContainer = nameContainer;
			poolContainer = new GameObject(nameContainer).transform;
		}

		public void Dispose()
		{
			ApplicationQuitStartObserver applicationQuitStartObserver = this.applicationQuitStartObserver;
			if (applicationQuitStartObserver == null || !applicationQuitStartObserver.IsInQuit)
			{
				if (disposePoolContainer && poolContainer != null)
				{
					UnityEngine.Object.Destroy(poolContainer.gameObject);
				}
				poolContainer = null;
				pool.Clear();
				pooledEntities.Clear();
			}
		}

		public GameObject Get(Transform parent = null)
		{
			PoolableEntity entity;
			return Get(parent, out entity);
		}

		public GameObject Get(Transform parent, out PoolableEntity entity)
		{
			if (TryGetFromPool(parent, out var entity2))
			{
				entity = entity2;
				return entity.gameObject;
			}
			entity = CreateInstance(parent);
			return entity.gameObject;
		}

		private bool TryGetFromPool(Transform parent, out PoolableEntity entity)
		{
			PoolableEntity result;
			while (pool.TryDequeue(out result))
			{
				pooledEntities.Remove(result);
				if (!(result == null))
				{
					result.transform.SetParent(parent, worldPositionStays: false);
					result.gameObject.SetActive(value: true);
					entity = result;
					return true;
				}
			}
			entity = null;
			return false;
		}

		private PoolableEntity CreateInstance(Transform parent)
		{
			GameObject gameObject = diContainer.InstantiatePrefab(prefab, parent);
			if (!gameObject.TryGetComponent<PoolableEntity>(out var component))
			{
				Debug.LogWarning($"An instance {gameObject} has been created that does not " + "have a PoolableEntity. We add forcibly.");
				component = gameObject.AddComponent<PoolableEntity>();
			}
			component.SourcePrefab = prefab;
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(value: true);
			}
			return component;
		}

		public void Release(GameObject instance)
		{
			PoolableEntity component;
			if (instance == null)
			{
				Debug.LogWarning("ConcreteGameObjectPool.Release called with null instance");
			}
			else if (!instance.TryGetComponent<PoolableEntity>(out component))
			{
				Debug.LogWarning(string.Format("{0}.{1} rejected: instance {2} does not have a {3} component", "ConcreteGameObjectPool", "Release", instance, "PoolableEntity"));
				UnityEngine.Object.Destroy(instance);
			}
			else
			{
				Release(component);
			}
		}

		public void Release(PoolableEntity instance)
		{
			if (instance == null)
			{
				Debug.LogWarning("ConcreteGameObjectPool.Release called with null instance");
			}
			else if (instance.SourcePrefab != prefab)
			{
				Debug.LogError("ConcreteGameObjectPool.Release rejected: instance's SourcePrefab component does not match this pool prefab " + prefab?.name);
			}
			else if (pooledEntities.Contains(instance))
			{
				Debug.LogWarning("ConcreteGameObjectPool.Release ignored: instance instance is already in pool");
			}
			else
			{
				ReleaseToPool(instance);
			}
		}

		private void ReleaseToPool(PoolableEntity instance)
		{
			Transform transform = prefab.transform;
			instance.Clean();
			instance.transform.SetParent(poolContainer);
			instance.gameObject.SetActive(value: false);
			instance.transform.SetPositionAndRotation(transform.position, transform.rotation);
			instance.transform.localScale = transform.localScale;
			pool.Enqueue(instance);
			pooledEntities.Add(instance);
		}
	}
}
