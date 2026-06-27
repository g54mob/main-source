using System;
using System.Collections.Generic;
using Restory.Data.ObjectPool;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.ObjectPools
{
	public class GlobalObjectPool : IInitializable, IDisposable
	{
		private readonly Dictionary<GameObject, Queue<GameObject>> prefabInstancesDictionary = new Dictionary<GameObject, Queue<GameObject>>();

		private DiContainer diContainer;

		private ObjectPoolSettings objectPoolSettings;

		private GameObject poolContainer;

		private GameObject prewarmItemsContainer;

		private GameObject destroyedObjectsContainer;

		private readonly List<IInitializable> initializablesCache = new List<IInitializable>();

		private ApplicationQuitStartObserver applicationQuitStartObserver;

		public bool IsActive => !applicationQuitStartObserver.IsInQuit;

		[Inject]
		private void Construct(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, [InjectOptional] ObjectPoolSettings objectPoolSettings)
		{
			this.diContainer = diContainer;
			this.objectPoolSettings = objectPoolSettings;
			this.applicationQuitStartObserver = applicationQuitStartObserver;
		}

		public void Initialize()
		{
			poolContainer = new GameObject("PoolContainer");
			destroyedObjectsContainer = new GameObject("PseudoDestroyedObjectsContainer");
			prewarmItemsContainer = new GameObject("PrewarmItemsContainer");
			prewarmItemsContainer.gameObject.SetActive(value: false);
		}

		public void Dispose()
		{
			ApplicationQuitStartObserver applicationQuitStartObserver = this.applicationQuitStartObserver;
			if (applicationQuitStartObserver != null && applicationQuitStartObserver.IsInQuit)
			{
				return;
			}
			foreach (KeyValuePair<GameObject, Queue<GameObject>> item in prefabInstancesDictionary)
			{
				_ = item.Key;
				item.Value?.Clear();
			}
			prefabInstancesDictionary.Clear();
			DestroyContainer(poolContainer);
			DestroyContainer(destroyedObjectsContainer);
			DestroyContainer(prewarmItemsContainer);
			initializablesCache.Clear();
			diContainer = null;
			poolContainer = null;
			destroyedObjectsContainer = null;
			prewarmItemsContainer = null;
		}

		private void DestroyContainer(GameObject container)
		{
			if ((bool)container)
			{
				UnityEngine.Object.Destroy(container);
			}
		}

		public T GetObject<T>(GameObject sourcePrefab, Transform parentTransform)
		{
			return GetObject(sourcePrefab, parentTransform).GetComponent<T>();
		}

		public GameObject GetObject(GameObject sourcePrefab, Transform parentTransform)
		{
			if (sourcePrefab == null || !IsActive)
			{
				return null;
			}
			GameObject instance = GetInstance(sourcePrefab, parentTransform);
			instance.transform.SetParent(parentTransform, worldPositionStays: false);
			instance.transform.localScale = Vector3.one;
			instance.SetActive(value: true);
			SetPrefabPoolableEntity(sourcePrefab, instance);
			return instance;
		}

		public GameObject GetObject(GameObject sourcePrefab, Vector3 worldPosition, Quaternion worldRotation)
		{
			if (sourcePrefab == null || !IsActive)
			{
				return null;
			}
			GameObject instance = GetInstance(sourcePrefab);
			instance.transform.position = worldPosition;
			instance.transform.rotation = worldRotation;
			instance.transform.localScale = Vector3.one;
			instance.SetActive(value: true);
			SetPrefabPoolableEntity(sourcePrefab, instance);
			return instance;
		}

		public void Clean(GameObject sourcePrefab, GameObject instance)
		{
			if (!IsActive)
			{
				return;
			}
			if (sourcePrefab == null)
			{
				MarkDestroyed(instance);
			}
			else if (!(instance == null))
			{
				InitializePool(sourcePrefab);
				if (CheckInstanceInPool(instance, sourcePrefab))
				{
					Debug.LogWarning("[GlobalObjectPool] the instance: " + instance.name + " already in pool!", instance);
					Deactivate(instance);
				}
				else
				{
					CleanPoolableEntity(instance);
					Deactivate(instance);
					prefabInstancesDictionary[sourcePrefab].Enqueue(instance);
				}
			}
		}

		private void InitializePool(GameObject prefab)
		{
			if (!prefabInstancesDictionary.ContainsKey(prefab))
			{
				prefabInstancesDictionary.Add(prefab, new Queue<GameObject>());
			}
		}

		private bool CheckInstanceInPool(GameObject instance, GameObject sourcePrefab)
		{
			if ((bool)instance && (bool)sourcePrefab && prefabInstancesDictionary.TryGetValue(sourcePrefab, out var value) && value.Count > 0)
			{
				return value.Contains(instance);
			}
			return false;
		}

		private void Deactivate(GameObject instance)
		{
			MoveToPoolContainer(instance);
			if (instance.activeSelf)
			{
				instance.SetActive(value: false);
			}
		}

		private void SetPrefabPoolableEntity(GameObject sourcePrefab, GameObject newInstance)
		{
			if (newInstance.TryGetComponent<PoolableEntity>(out var component))
			{
				component.SourcePrefab = sourcePrefab;
			}
		}

		private static void CleanPoolableEntity(GameObject instance)
		{
			if (instance.TryGetComponent<PoolableEntity>(out var component))
			{
				component.Clean();
			}
		}

		private GameObject GetInstance(GameObject sourcePrefab, Transform parent = null)
		{
			if (!sourcePrefab)
			{
				Debug.LogWarning("[GlobalObjectPool] GetInstance can't complete.Reason: sourcePrefab is null");
				return null;
			}
			InitializePool(sourcePrefab);
			Queue<GameObject> queue = prefabInstancesDictionary[sourcePrefab];
			GameObject gameObject = null;
			while (gameObject == null)
			{
				if (queue.Count > 0)
				{
					gameObject = queue.Dequeue();
				}
				else if (diContainer != null)
				{
					gameObject = InstantiatePrefab(sourcePrefab, parent);
					AutoExpandPrewarmSize(sourcePrefab);
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate(sourcePrefab, parent);
				}
			}
			return gameObject;
		}

		private GameObject InstantiatePrefab(GameObject sourcePrefab, Transform parent = null)
		{
			return diContainer.InstantiatePrefab(sourcePrefab, parent);
		}

		private void MoveToPoolContainer(GameObject instance)
		{
			if ((bool)instance && (bool)poolContainer && instance.activeSelf)
			{
				instance.transform.SetParent(poolContainer.transform, worldPositionStays: false);
			}
		}

		private void MarkDestroyed(GameObject instance)
		{
			if ((bool)instance && IsActive)
			{
				if (instance.activeSelf)
				{
					instance.SetActive(value: false);
				}
				if ((bool)destroyedObjectsContainer)
				{
					instance.transform.SetParent(destroyedObjectsContainer.transform, worldPositionStays: false);
				}
			}
		}

		public void Prewarm(GameObject prefab, int instantiateAmount)
		{
			InitializePool(prefab);
			Queue<GameObject> queue = prefabInstancesDictionary[prefab];
			for (int i = 0; i < instantiateAmount; i++)
			{
				GameObject gameObject = InstantiatePrefab(prefab, prewarmItemsContainer.transform);
				queue.Enqueue(gameObject);
				if (gameObject.activeSelf)
				{
					gameObject.SetActive(value: false);
				}
			}
		}

		private bool IsFitPoolSize(GameObject prefab)
		{
			if (!objectPoolSettings)
			{
				return true;
			}
			int maxPoolSize = objectPoolSettings.GetMaxPoolSize(prefab);
			if (maxPoolSize == -1)
			{
				return true;
			}
			if (!prefabInstancesDictionary.TryGetValue(prefab, out var value))
			{
				return true;
			}
			return value.Count < maxPoolSize;
		}

		private void AutoExpandPrewarmSize(GameObject prefab)
		{
		}

		private void ExpandPrewarmSize(GameObject prefab)
		{
		}
	}
}
