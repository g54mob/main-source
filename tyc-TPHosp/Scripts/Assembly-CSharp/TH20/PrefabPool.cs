#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class PrefabPool : MustCallDestroy
	{
		private List<GameObject> _mUnusedInstanceList = new List<GameObject>();

		private List<GameObject> _mUsedInstanceList = new List<GameObject>();

		private readonly Transform _mUnusedInstancesContainer;

		private int _mPoolSize;

		private readonly bool _reparentByDefault;

		public GameObject Prefab { get; private set; }

		public PrefabPool(GameObject inPrefab, int inInitialSize, bool reparentByDefault, Transform unusedInstancesContainer = null)
		{
			Prefab = inPrefab;
			_mPoolSize = inInitialSize;
			_mUnusedInstancesContainer = unusedInstancesContainer;
			_reparentByDefault = reparentByDefault;
			CreatePrefabPool();
		}

		private void CreatePrefabPool()
		{
			SetPoolName();
			_mUnusedInstanceList = new List<GameObject>(_mPoolSize);
			_mUsedInstanceList = new List<GameObject>(_mPoolSize);
			for (int i = 0; i < _mPoolSize; i++)
			{
				CreateInstance(inActivateInstance: false);
			}
		}

		public void GatherInstanceIDs(ref Dictionary<int, int> instanceMap, int poolID, Func<GameObject, int> GetObjectID)
		{
			for (int i = 0; i < _mPoolSize; i++)
			{
				int key = GetObjectID(_mUnusedInstanceList[i]);
				if (!instanceMap.ContainsKey(key))
				{
					instanceMap.Add(key, poolID);
				}
			}
		}

		public override void Destroy()
		{
			_mUsedInstanceList.ClearAndDestroy();
			_mUnusedInstanceList.ClearAndDestroy();
			if (_mUnusedInstancesContainer != null)
			{
				UnityEngine.Object.Destroy(_mUnusedInstancesContainer.gameObject);
			}
			base.Destroy();
		}

		private GameObject CreateInstance(bool inActivateInstance)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Prefab);
			gameObject.name = Prefab.name;
			GameObjectUtils.SetParent(gameObject.transform, _mUnusedInstancesContainer);
			GameObjectUtils.SetActive(gameObject, inActivateInstance);
			_mUnusedInstanceList.Add(gameObject);
			return gameObject;
		}

		public GameObject GetInstance()
		{
			if (_mUnusedInstanceList.Count == 0)
			{
				CreateInstance(inActivateInstance: true);
				_mPoolSize++;
			}
			int count = _mUnusedInstanceList.Count;
			GameObject gameObject = _mUnusedInstanceList[count - 1];
			GameObjectUtils.SetActive(gameObject.gameObject, isActive: true);
			GameObjectUtils.SetParent(gameObject.transform, null);
			_mUnusedInstanceList.RemoveAt(count - 1);
			_mUsedInstanceList.Add(gameObject);
			SetPoolName();
			return gameObject;
		}

		public GameObject GetInstance(Transform parent, out bool wasJustInstantiated, bool worldPositionStay = true, bool isActive = true)
		{
			wasJustInstantiated = false;
			if (_mUnusedInstanceList.RemoveAll((GameObject x) => x == null) > 0)
			{
				Logging.Warning("Had to remove null objects from pool " + Prefab.name + ". This means the objects are getting destroyed instead of returned to the pool");
			}
			if (_mUnusedInstanceList.Count == 0)
			{
				CreateInstance(isActive);
				_mPoolSize++;
				wasJustInstantiated = true;
			}
			int count = _mUnusedInstanceList.Count;
			GameObject gameObject = _mUnusedInstanceList[count - 1];
			if (gameObject.transform.parent != parent)
			{
				GameObjectUtils.SetParent(gameObject.transform, parent, worldPositionStay);
			}
			GameObjectUtils.SetActive(gameObject.gameObject, isActive);
			_mUnusedInstanceList.RemoveAt(count - 1);
			_mUsedInstanceList.Add(gameObject);
			SetPoolName();
			return gameObject;
		}

		public T GetInstance<T>(Transform parent, out bool wasJustInstantiated, bool worldPositionStay = true, bool isActive = true) where T : MonoBehaviour
		{
			return GetInstance(parent, out wasJustInstantiated, worldPositionStay, isActive).GetComponent<T>();
		}

		public void ReturnInstance(GameObject inGameObject, bool reparent = false)
		{
			bool num = _mUsedInstanceList.Remove(inGameObject);
			bool flag = _mUnusedInstanceList.Contains(inGameObject);
			if (num || flag)
			{
				GameObjectUtils.SetActive(inGameObject, isActive: false);
				if (!flag)
				{
					_mUnusedInstanceList.Add(inGameObject);
				}
				if (reparent || _reparentByDefault)
				{
					GameObjectUtils.SetParent(inGameObject.transform, _mUnusedInstancesContainer);
				}
				SetPoolName();
			}
		}

		private void SetPoolName()
		{
		}
	}
}
