#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class ComponentPool<T> where T : Component, IPoolableComponent
	{
		private readonly Queue<T> _pool = new Queue<T>();

		private readonly T _prefab;

		private readonly Transform _parent;

		private readonly bool _autoExpand;

		private Quaternion _defaultRotation;

		private readonly int _supposedAmount;

		public bool AutoExpand => _autoExpand;

		public ComponentPool(int supposedAmount, T prefab, Transform parent = null, Quaternion defaultRotation = default(Quaternion), bool autoExpand = true)
		{
			if (prefab == null)
			{
				this.LogError($"Pool for {typeof(T)} was given a null prefab", ".ctor", 19);
			}
			_prefab = prefab;
			_parent = parent;
			_supposedAmount = supposedAmount;
			_autoExpand = autoExpand;
			_defaultRotation = defaultRotation;
			if (_defaultRotation == default(Quaternion))
			{
				_defaultRotation = Quaternion.identity;
			}
		}

		public bool TryAutoBalance()
		{
			if (!_autoExpand)
			{
				return false;
			}
			if (_supposedAmount <= _pool.Count)
			{
				return false;
			}
			AddNewInstanceToPool();
			return true;
		}

		private void AddNewInstanceToPool()
		{
			T val = CreateNewInstance();
			val.OnReturnToPool();
			_pool.Enqueue(val);
		}

		public T GetComponent()
		{
			if (_pool.Count <= 0)
			{
				return CreateNewInstance();
			}
			T val = _pool.Dequeue();
			val.OnRetrieveFromPool();
			return val;
		}

		private T CreateNewInstance()
		{
			return Object.Instantiate(_prefab, Vector3.zero, _defaultRotation, _parent);
		}

		public void ReturnMono(T mono)
		{
			if (mono.transform.parent != _parent)
			{
				mono.transform.SetParent(_parent);
			}
			mono.OnReturnToPool();
			_pool.Enqueue(mono);
		}
	}
}
