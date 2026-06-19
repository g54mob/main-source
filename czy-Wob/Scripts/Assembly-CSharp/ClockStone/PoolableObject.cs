using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClockStone
{
	[AddComponentMenu("ClockStone/PoolableObject")]
	public class PoolableObject : MonoBehaviour
	{
		[Tooltip("Specifies the maximum number of objects on the pool")]
		public int maxPoolSize = 10;

		[Tooltip("Specifies the number of objects that will be created on the pool at program start (improves speed of later instantiation)")]
		public int preloadCount;

		[Tooltip("If enabled the pool of deactivated objects will surivive a scene change")]
		public bool doNotDestroyOnLoad;

		public bool sendAwakeStartOnDestroyMessage = true;

		public bool sendPoolableActivateDeactivateMessages;

		public bool useReflectionInsteadOfMessages;

		internal bool _isInPool;

		internal ObjectPoolController.ObjectPool _pool;

		internal int _serialNumber;

		internal int _usageCount;

		internal bool _awakeJustCalledByUnity;

		internal bool _wasInstantiatedByObjectPoolController;

		private bool _justInvokingOnDestroy;

		public bool isPooledInstance => _pool != null;

		protected void Awake()
		{
			_awakeJustCalledByUnity = true;
		}

		protected void OnDestroy()
		{
			if (!_justInvokingOnDestroy && _pool != null)
			{
				_pool.Remove(this);
			}
		}

		public int GetSerialNumber()
		{
			return _serialNumber;
		}

		public int GetUsageCount()
		{
			return _usageCount;
		}

		public int DeactivateAllPoolableObjectsOfMyKind()
		{
			if (_pool != null)
			{
				return _pool._SetAllAvailable();
			}
			return 0;
		}

		public bool IsDeactivated()
		{
			return _isInPool;
		}

		internal void _PutIntoPool()
		{
			if (_pool == null)
			{
				Debug.LogError("Tried to put object into pool which was not created with ObjectPoolController", this);
				return;
			}
			if (_isInPool)
			{
				if (base.transform.parent != _pool.poolParent)
				{
					Debug.LogWarning("Object was already in pool but parented to Pool-Parent. Reparented.", this);
					base.transform.parent = _pool.poolParent;
					if (base.transform.parent != _pool.poolParent)
					{
						Debug.LogError("Object couldn\u00b4t be reparented. Deleted");
						Object.DestroyImmediate(base.gameObject);
					}
				}
				else
				{
					Debug.LogWarning("Object is already in Pool", this);
				}
				return;
			}
			if (!ObjectPoolController._isDuringInstantiate)
			{
				if (sendAwakeStartOnDestroyMessage)
				{
					_justInvokingOnDestroy = true;
					_pool.CallMethodOnObject(base.gameObject, "OnDestroy", includeChildren: true, includeInactive: true, useReflectionInsteadOfMessages);
					_justInvokingOnDestroy = false;
				}
				if (sendPoolableActivateDeactivateMessages)
				{
					_pool.CallMethodOnObject(base.gameObject, "OnPoolableObjectDeactivated", includeChildren: true, includeInactive: true, useReflectionInsteadOfMessages);
				}
			}
			_isInPool = true;
			base.transform.SetParent(_pool.poolParent, worldPositionStays: true);
			base.gameObject.SetActive(value: false);
		}

		internal void TakeFromPool(Transform parent, bool activateObject)
		{
			if (!_isInPool)
			{
				Debug.LogError("Tried to take an object from Pool which is not available!", this);
				return;
			}
			_isInPool = false;
			_usageCount++;
			base.transform.SetParent(parent, worldPositionStays: true);
			if (parent == null)
			{
				SceneManager.MoveGameObjectToScene(base.gameObject, SceneManager.GetActiveScene());
			}
			if (!activateObject)
			{
				return;
			}
			_awakeJustCalledByUnity = false;
			base.gameObject.SetActive(value: true);
			if (sendAwakeStartOnDestroyMessage && !_awakeJustCalledByUnity)
			{
				_pool.CallMethodOnObject(base.gameObject, "Awake", includeChildren: true, includeInactive: false, useReflectionInsteadOfMessages);
				if (base.gameObject.activeInHierarchy)
				{
					_pool.CallMethodOnObject(base.gameObject, "Start", includeChildren: true, includeInactive: false, useReflectionInsteadOfMessages);
				}
			}
			if (sendPoolableActivateDeactivateMessages)
			{
				_pool.CallMethodOnObject(base.gameObject, "OnPoolableObjectActivated", includeChildren: true, includeInactive: true, useReflectionInsteadOfMessages);
			}
		}
	}
}
