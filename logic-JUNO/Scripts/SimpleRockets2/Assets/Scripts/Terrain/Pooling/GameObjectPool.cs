using UnityEngine;

namespace Assets.Scripts.Terrain.Pooling
{
	public class GameObjectPool<T> : QuadSpherePool<T> where T : Component
	{
		private Transform _poolRoot;

		public GameObject Prefab { get; protected set; }

		public GameObjectPool(string poolName, string prefabPath, int initialSize)
			: base(initialSize)
		{
			Prefab = Game.Instance.ResourceLoader.LoadPrefab(prefabPath);
			_poolRoot = new GameObject(poolName).transform;
			_poolRoot.SetParent(QuadSpherePoolManager.Instance.transform, worldPositionStays: false);
		}

		public override void ReturnItem(QuadSpherePoolItem<T> item)
		{
			if (item.State == QuadSpherePoolItemState.PendingDestruction)
			{
				Destroy(item);
				return;
			}
			base.AvailablePool.Enqueue(item);
			item.Item.transform.SetParent(_poolRoot, worldPositionStays: false);
			item.Item.gameObject.SetActive(value: false);
		}

		protected override T CreateItem(int id)
		{
			T component = Object.Instantiate(Prefab).GetComponent<T>();
			component.transform.SetParent(_poolRoot, worldPositionStays: false);
			component.gameObject.SetActive(value: false);
			return component;
		}

		protected override void Destroy(T item)
		{
			Object.Destroy(item.gameObject);
		}
	}
}
