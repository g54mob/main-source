using System;
using UnityEngine;

namespace Factory.Allocators
{
	public class GameObjectAllocator<T> : IAllocator<T>, IDisposable where T : Component
	{
		private readonly GameObject _prefab;

		public GameObjectAllocator(string bundleName, string prefabName)
		{
			_prefab = AssetBundleUtility.LoadPrefab(bundleName, prefabName);
		}

		public GameObjectAllocator(GameObject prefab)
		{
			_prefab = prefab;
		}

		public void Dispose()
		{
		}

		public T Allocate(IScope context)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_prefab);
			gameObject.SetActive(value: true);
			return (T)gameObject.GetComponent(typeof(T));
		}

		public bool Release(T obj, IScope context)
		{
			obj.transform.SetParent(null);
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(obj.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(obj.gameObject);
			}
			return true;
		}

		public virtual void OnObjectAssembled(T obj, IScope context)
		{
		}
	}
}
