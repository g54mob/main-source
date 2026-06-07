using System.Collections.Generic;
using PajamaLlama.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PajamaLlama
{
	public class PrefabPool
	{
		private class PrefabReference : MonoBehaviour
		{
			public Object prefab;

			private void OnDestroy()
			{
				Debug.LogWarningFormat("'{0}' which was instantiate by the PrefabPool was destroyed!", base.name);
			}
		}

		private GameObject _prefab;

		private string _pooledInstanceParentName;

		private Queue<GameObject> _pooledInstances;

		private Transform _pooledInstanceParent;

		private List<GameObject> _usedInstances;

		private static Transform _prefabPoolParent;

		private static Dictionary<Object, Queue<GameObject>> _pooledGameObjects;

		private static Dictionary<Object, Queue<Component>> _pooledComponents;

		public PrefabPool(GameObject prefab, string pooledInstanceParentName, int capacity = 32)
		{
			_prefab = prefab;
			_pooledInstanceParentName = pooledInstanceParentName;
			_pooledInstances = new Queue<GameObject>(capacity);
			_usedInstances = new List<GameObject>(capacity);
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		~PrefabPool()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
		}

		public GameObject GetInstance()
		{
			if (!TryDequeueInstance(out var instance))
			{
				instance = Object.Instantiate(_prefab);
			}
			instance.SetActive(value: true);
			_usedInstances.Add(instance);
			return instance;
		}

		public void ReleaseInstance(GameObject instance)
		{
			if (_usedInstances.Contains(instance))
			{
				instance.transform.SetParent(GetPooledInstanceParent());
				instance.SetActive(value: false);
				_pooledInstances.Enqueue(instance);
			}
		}

		private bool TryDequeueInstance(out GameObject instance)
		{
			instance = null;
			while (0 < _pooledInstances.Count)
			{
				instance = _pooledInstances.Dequeue();
				if ((bool)instance)
				{
					return true;
				}
			}
			return false;
		}

		private Transform InstantiatePooledInstanceParent(string name)
		{
			if (_prefabPoolParent == null)
			{
				_prefabPoolParent = new GameObject("Prefab Pool").transform;
			}
			if (string.IsNullOrEmpty(name))
			{
				return _prefabPoolParent;
			}
			return _prefabPoolParent.GetOrInstantiateChildWithName(name);
		}

		private void OnSceneUnloaded(Scene scene)
		{
			if (_pooledInstances != null)
			{
				int count = _pooledInstances.Count;
				for (int i = 0; i < count; i++)
				{
					GameObject gameObject = _pooledInstances.Dequeue();
					if ((bool)gameObject)
					{
						_pooledInstances.Enqueue(gameObject);
					}
				}
			}
			if (_usedInstances == null)
			{
				return;
			}
			int count2 = _usedInstances.Count;
			while (0 < count2--)
			{
				if (!_usedInstances[count2])
				{
					_usedInstances.RemoveAt(count2);
				}
			}
		}

		private Transform GetPooledInstanceParent()
		{
			if ((bool)_pooledInstanceParent)
			{
				return _pooledInstanceParent;
			}
			_pooledInstanceParent = InstantiatePooledInstanceParent(_pooledInstanceParentName);
			return _pooledInstanceParent;
		}

		public static void InitializeStaticPools(Transform parent)
		{
			if (_pooledGameObjects == null)
			{
				_pooledGameObjects = new Dictionary<Object, Queue<GameObject>>();
			}
			if (_pooledComponents == null)
			{
				_pooledComponents = new Dictionary<Object, Queue<Component>>();
			}
			_prefabPoolParent = parent;
		}

		public static void ClearStaticPools()
		{
			_pooledGameObjects?.Clear();
			_pooledComponents?.Clear();
		}

		public static GameObject GetInstance(GameObject original)
		{
			GameObject result;
			if (_pooledGameObjects.TryGetValue(original, out var value))
			{
				while (value.TryDequeue(out result))
				{
					if ((bool)result)
					{
						result.SetActive(original.activeSelf);
						return result;
					}
				}
			}
			result = Object.Instantiate(original);
			result.AddComponent<PrefabReference>().prefab = original;
			return result;
		}

		public static GameObject GetInstance(GameObject original, Transform parent, bool worldPositionStays = false)
		{
			GameObject instance = GetInstance(original);
			instance.transform.SetParent(parent, worldPositionStays);
			return instance;
		}

		public static GameObject GetInstance(GameObject original, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject instance = GetInstance(original);
			Transform transform = instance.transform;
			if ((bool)parent)
			{
				transform.SetParent(parent);
			}
			transform.position = position;
			transform.rotation = rotation;
			return instance;
		}

		public static T GetInstance<T>(T original) where T : Component
		{
			Component result;
			if (_pooledComponents.TryGetValue(original, out var value))
			{
				while (value.TryDequeue(out result))
				{
					if ((bool)result)
					{
						result.gameObject.SetActive(original.gameObject.activeSelf);
						return result as T;
					}
				}
			}
			result = Object.Instantiate(original);
			result.gameObject.AddComponent<PrefabReference>().prefab = original;
			return result as T;
		}

		public static T GetInstance<T>(T original, Transform parent, bool worldPositionStays = false) where T : Component
		{
			T instance = GetInstance(original);
			instance.transform.SetParent(parent, worldPositionStays);
			return instance;
		}

		public static T GetInstance<T>(T original, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component
		{
			T instance = GetInstance(original);
			Transform transform = instance.transform;
			if ((bool)parent)
			{
				transform.SetParentAndReset(parent);
			}
			transform.position = position;
			transform.rotation = rotation;
			return instance;
		}

		public static void Repool(GameObject gameObject)
		{
			if (gameObject.TryGetComponent<PrefabReference>(out var component))
			{
				if (_pooledGameObjects.TryGetValue(component.prefab, out var value))
				{
					if (value.Contains(gameObject))
					{
						Debug.LogWarningFormat("Trying to repool '{0}' which is already in the PrefabPool!", gameObject);
					}
					else
					{
						value.Enqueue(gameObject);
					}
				}
				else
				{
					Queue<GameObject> queue = new Queue<GameObject>();
					queue.Enqueue(gameObject);
					_pooledGameObjects.Add(component.prefab, queue);
				}
				gameObject.transform.SetParentAndReset(_prefabPoolParent);
				gameObject.SetActive(value: false);
			}
			else
			{
				Debug.LogWarning("PrefabPool.Release was called for an instance that was not instantiated by the PrefabPool");
			}
		}

		public static void Repool(Component component)
		{
			if (component.gameObject.TryGetComponent<PrefabReference>(out var component2))
			{
				if (_pooledComponents.TryGetValue(component2.prefab, out var value))
				{
					if (value.Contains(component))
					{
						Debug.LogWarningFormat("Trying to repool '{0}' which is already in the PrefabPool!", component);
					}
					else
					{
						value.Enqueue(component);
					}
				}
				else
				{
					Queue<Component> queue = new Queue<Component>();
					queue.Enqueue(component);
					_pooledComponents.Add(component2.prefab, queue);
				}
				component.transform.SetParentAndReset(_prefabPoolParent);
				component.gameObject.SetActive(value: false);
			}
			else
			{
				Debug.LogWarning("PrefabPool.Release was called for an instance that was not instantiated by the PrefabPool");
			}
		}
	}
}
