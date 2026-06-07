using UnityEngine;

namespace ClockStone
{
	public class PoolableObject : MonoBehaviour
	{
		public int maxPoolSize;

		public int preloadCount;

		public bool doNotDestroyOnLoad;

		public bool sendAwakeStartOnDestroyMessage;

		public bool sendPoolableActivateDeactivateMessages;

		public bool useReflectionInsteadOfMessages;

		internal bool _isInPool;

		internal ObjectPoolController.ObjectPool _pool;

		internal int _serialNumber;

		internal int _usageCount;

		internal bool _awakeJustCalledByUnity;

		internal bool _instantiatedByObjectPoolController;

		private bool _justInvokingOnDestroy;

		protected void Awake()
		{
		}

		protected void OnDestroy()
		{
		}

		public int GetSerialNumber()
		{
			return 0;
		}

		public int GetUsageCount()
		{
			return 0;
		}

		public int DeactivateAllPoolableObjectsOfMyKind()
		{
			return 0;
		}

		public bool IsDeactivated()
		{
			return false;
		}

		internal void _PutIntoPool()
		{
		}

		internal void TakeFromPool(Transform parent, bool activateObject)
		{
		}
	}
}
