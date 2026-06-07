using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class GameObjectPoolManager<T> where T : MonoBehaviour
	{
		private readonly Func<T> _createAction;

		private readonly Queue<T> _useableGameObjects;

		private readonly int _maxCapacity;

		private readonly Action<T> _initAction;

		public GameObjectPoolManager(Func<T> createAction, Action<T> initAction, int maxCapacity)
		{
			_createAction = createAction;
			_initAction = initAction;
			_maxCapacity = maxCapacity;
			_useableGameObjects = new Queue<T>(maxCapacity);
		}

		public T Instantiate(Vector3 position, Quaternion rotation)
		{
			if (_useableGameObjects.Count > 0)
			{
				T val = _useableGameObjects.Dequeue();
				val.transform.parent = null;
				val.transform.localScale = Vector3.one;
				val.transform.position = position;
				val.transform.rotation = rotation;
				val.gameObject.SetActive(true);
				_initAction(val);
				return val;
			}
			T val2 = _createAction();
			val2.transform.position = position;
			val2.transform.rotation = rotation;
			return val2;
		}

		public void Destroy(T obj)
		{
			if (_useableGameObjects.Count > _maxCapacity)
			{
				UnityEngine.Object.Destroy(obj.gameObject);
				return;
			}
			obj.gameObject.SetActive(false);
			_useableGameObjects.Enqueue(obj);
		}
	}
}
