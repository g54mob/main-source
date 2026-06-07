using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectPool
	{
		public enum GrowMode
		{
			None = 0,
			Increment = 1,
			ByAmount = 2
		}

		private GameObject _sourceObject;

		private GrowMode _growMode = GrowMode.ByAmount;

		private int _growAmount = 50;

		private List<GameObject> _pooledObjects = new List<GameObject>(100);

		private Transform _pooledParent;

		public GrowMode PoolGrowMode
		{
			get
			{
				return _growMode;
			}
			set
			{
				_growMode = value;
			}
		}

		public int GrowAmount
		{
			get
			{
				return _growAmount;
			}
			set
			{
				_growAmount = Mathf.Max(1, value);
			}
		}

		public ObjectPool(GameObject sourceObject, int numPooled, GrowMode growMode)
		{
			_sourceObject = sourceObject;
			_growMode = growMode;
		}

		public void SetPooledObjectsParent(Transform parent)
		{
			_pooledParent = parent;
			foreach (GameObject pooledObject in _pooledObjects)
			{
				if (pooledObject != null && !pooledObject.activeSelf)
				{
					pooledObject.transform.SetParent(parent, worldPositionStays: false);
				}
			}
		}

		public GameObject GetPooledObject()
		{
			foreach (GameObject pooledObject in _pooledObjects)
			{
				if (pooledObject != null && !pooledObject.activeSelf)
				{
					pooledObject.SetActive(value: true);
					if (_pooledParent != null)
					{
						pooledObject.transform.SetParent(_pooledParent, worldPositionStays: false);
					}
					return pooledObject;
				}
			}
			if (PoolGrowMode != GrowMode.None)
			{
				int count = _pooledObjects.Count;
				Grow();
				GameObject gameObject = _pooledObjects[count];
				gameObject.SetActive(value: true);
				if (_pooledParent != null)
				{
					gameObject.transform.SetParent(_pooledParent, worldPositionStays: false);
				}
				return gameObject;
			}
			return null;
		}

		public void MarkAsUnused(GameObject gameObject)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}

		public void MarkAllAsUnused()
		{
			foreach (GameObject pooledObject in _pooledObjects)
			{
				MarkAsUnused(pooledObject);
			}
		}

		private void Grow()
		{
			if (PoolGrowMode == GrowMode.None)
			{
				return;
			}
			if (PoolGrowMode == GrowMode.ByAmount)
			{
				for (int i = 0; i < GrowAmount; i++)
				{
					CreatePooledObject();
				}
			}
			else if (PoolGrowMode == GrowMode.Increment)
			{
				CreatePooledObject();
			}
		}

		private GameObject CreatePooledObject()
		{
			GameObject gameObject = Object.Instantiate(_sourceObject);
			_pooledObjects.Add(gameObject);
			if (_pooledParent != null)
			{
				gameObject.transform.SetParent(_pooledParent, worldPositionStays: false);
			}
			gameObject.SetActive(value: false);
			return gameObject;
		}
	}
}
