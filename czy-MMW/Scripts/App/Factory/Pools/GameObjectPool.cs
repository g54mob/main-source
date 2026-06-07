using Factory.Allocators;
using UnityEngine;

namespace Factory.Pools
{
	public class GameObjectPool<T> : Pool<T> where T : Component, IReusable
	{
		public GameObjectPool(string bundleName, string prefabName)
			: base((IAllocator<T>)new GameObjectAllocator<T>(bundleName, prefabName))
		{
		}

		public GameObjectPool(GameObject prefab)
			: base((IAllocator<T>)new GameObjectAllocator<T>(prefab))
		{
		}

		protected override void OnObjectCreated(T obj, IScope context)
		{
			obj.gameObject.SetActive(value: false);
		}

		protected override void OnObjectAllocated(T obj, IScope context)
		{
			obj.gameObject.SetActive(value: true);
		}

		protected override void OnObjectReleased(T obj, IScope context)
		{
			obj.gameObject.SetActive(value: false);
		}
	}
}
