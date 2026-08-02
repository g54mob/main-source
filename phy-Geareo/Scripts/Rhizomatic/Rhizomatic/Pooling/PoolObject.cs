using UnityEngine;

namespace Rhizomatic.Pooling
{
	public class PoolObject : MonoBehaviour
	{
		private bool created;

		public bool pooled { get; private set; }

		public bool poolActive { get; private set; }

		public object poolKey { get; private set; }

		public ObjectPool pool { get; private set; }

		public PoolObject poolPrefab { get; private set; }

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void OnCreated()
		{
		}

		protected virtual void OnSpawned()
		{
		}

		protected virtual void OnPooled()
		{
		}

		protected virtual void OnDestroyed()
		{
		}

		public void _OnCreated(object poolKey, ObjectPool pool, PoolObject prefab)
		{
		}

		public void _OnSpawned()
		{
		}

		public void _OnPooled()
		{
		}

		public void _OnDestroyed()
		{
		}

		public void Pool()
		{
		}

		public void Destroy()
		{
		}

		public void SetActive(bool active)
		{
		}
	}
}
