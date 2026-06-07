using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class GameObjectPool
	{
		private static Transform _defaultParent;

		public static Transform DefaultParent
		{
			get
			{
				if (_defaultParent == null)
				{
					_defaultParent = new GameObject("GameObjectPools").transform;
				}
				return _defaultParent;
			}
		}
	}
	public class GameObjectPool<T> : GameObjectPool where T : Component
	{
		protected struct PoolObject
		{
			public T ObjectScript;

			public GameObjectPoolItemScript PoolScript;
		}

		private PoolObject[] _buffer;

		private int _lastUsedIndex;

		private float _objectLifeTime;

		private Object _resource;

		public Transform Container { get; private set; }

		public GameObjectPool(Transform parent, int maxPoolSize, string prefab, float lifeTime)
		{
			_objectLifeTime = lifeTime;
			_buffer = new PoolObject[maxPoolSize];
			_resource = Resources.Load(prefab);
			GameObject gameObject = new GameObject("Pool-" + prefab);
			Container = gameObject.transform;
			Container.parent = parent;
		}

		public T Create()
		{
			PoolObject poolObject;
			for (int i = 0; i < _buffer.Length; i++)
			{
				poolObject = _buffer[i];
				if (poolObject.PoolScript == null)
				{
					GameObject gameObject = Object.Instantiate(_resource) as GameObject;
					gameObject.transform.SetParent(Container);
					poolObject.PoolScript = gameObject.AddComponent<GameObjectPoolItemScript>();
					poolObject.PoolScript.GameObject = gameObject;
					poolObject.PoolScript.LifeTime = _objectLifeTime;
					poolObject.PoolScript.Restart();
					poolObject.ObjectScript = gameObject.GetComponent<T>();
					_lastUsedIndex = i;
					_buffer[i] = poolObject;
					return poolObject.ObjectScript;
				}
				if (!poolObject.PoolScript.GameObject.activeSelf)
				{
					_lastUsedIndex = i;
					poolObject.PoolScript.Restart();
					return poolObject.ObjectScript;
				}
			}
			_lastUsedIndex++;
			if (_lastUsedIndex >= _buffer.Length)
			{
				_lastUsedIndex = 0;
			}
			poolObject = _buffer[_lastUsedIndex];
			poolObject.PoolScript.Restart();
			return poolObject.ObjectScript;
		}
	}
}
