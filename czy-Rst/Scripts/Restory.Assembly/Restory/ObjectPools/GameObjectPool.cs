using System;
using System.Collections.Generic;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.ObjectPools
{
	public class GameObjectPool : IDisposable
	{
		private readonly string nameContainer;

		private readonly Dictionary<GameObject, Queue<PoolableEntity>> pools = new Dictionary<GameObject, Queue<PoolableEntity>>();

		private readonly HashSet<PoolableEntity> pooledEntities = new HashSet<PoolableEntity>();

		private readonly bool disposePoolContainer = true;

		private Transform poolContainer;

		private readonly ApplicationQuitStartObserver applicationQuitStartObserver;

		private readonly DiContainer diContainer;

		public GameObjectPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, string nameContainer = "GameObjectPoolContainer")
		{
			this.diContainer = diContainer;
			this.applicationQuitStartObserver = applicationQuitStartObserver;
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
				pools.Clear();
				pooledEntities.Clear();
			}
		}

		public PoolableEntity Get(GameObject prefab, Transform parent = null)
		{
			if (prefab == null)
			{
				return null;
			}
			if (TryGetFromPool(prefab, parent, out var entity))
			{
				return entity;
			}
			return CreateInstance(prefab, parent);
		}

		private bool TryGetFromPool(GameObject prefab, Transform parent, out PoolableEntity entity)
		{
			if (pools.TryGetValue(prefab, out var value))
			{
				PoolableEntity result;
				while (value.TryDequeue(out result))
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
			}
			entity = null;
			return false;
		}

		private PoolableEntity CreateInstance(GameObject prefab, Transform parent)
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

		public void Release(PoolableEntity instance)
		{
			if (!(instance == null) && !(instance.SourcePrefab == null) && !pooledEntities.Contains(instance))
			{
				if (!pools.ContainsKey(instance.SourcePrefab))
				{
					pools[instance.SourcePrefab] = new Queue<PoolableEntity>();
				}
				ReleaseToPool(instance);
			}
		}

		private void ReleaseToPool(PoolableEntity instance)
		{
			GameObject sourcePrefab = instance.SourcePrefab;
			Transform transform = sourcePrefab.transform;
			instance.Clean();
			instance.transform.SetParent(poolContainer);
			instance.gameObject.SetActive(value: false);
			instance.transform.SetPositionAndRotation(transform.position, transform.rotation);
			instance.transform.localScale = transform.localScale;
			pools[sourcePrefab].Enqueue(instance);
			pooledEntities.Add(instance);
		}
	}
}
