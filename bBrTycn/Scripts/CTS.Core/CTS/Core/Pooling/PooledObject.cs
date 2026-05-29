using System;
using UnityEngine;

namespace CTS.Core.Pooling
{
	[DefaultExecutionOrder(-1)]
	public class PooledObject : CTSBehaviour, IPoolable
	{
		private int _poolID;

		private bool _autoReturn;

		[Inject(false)]
		[InjectScope(EGetScope.Children)]
		private IPoolable[] _poolables;

		[Inject(false)]
		[InjectScope(EGetScope.Children)]
		private IPoolCallbackReceiver[] _callbackReceivers;

		internal Component PoolComponent { get; private set; }

		private bool Destroyed { get; set; }

		internal bool InPool { get; set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		public static implicit operator GameObject(PooledObject obj)
		{
			return obj.gameObject;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if (!InPool && _autoReturn)
			{
				PushToPool();
			}
		}

		private void OnDestroy()
		{
			if (!Destroyed)
			{
				Destroyed = true;
				Pooler.Clear(this, _poolID);
			}
		}

		internal void Setup(int poolID, Component poolComponent, bool autoReturn)
		{
			_poolID = poolID;
			PoolComponent = (poolComponent ? poolComponent : this);
			_autoReturn = autoReturn;
			SetPoolGuid();
		}

		internal void Pulled()
		{
			if (_callbackReceivers != null)
			{
				IPoolCallbackReceiver[] callbackReceivers = _callbackReceivers;
				for (int i = 0; i < callbackReceivers.Length; i++)
				{
					callbackReceivers[i].OnPulled();
				}
			}
		}

		public void SetAutoReturn(bool autoReturn)
		{
			_autoReturn = autoReturn;
		}

		public void PushToPool()
		{
			if (Destroyed || InPool || !base.gameObject.scene.isLoaded)
			{
				return;
			}
			Pooler.Push(this, PoolComponent, _poolID);
			if (_callbackReceivers != null)
			{
				IPoolCallbackReceiver[] callbackReceivers = _callbackReceivers;
				for (int i = 0; i < callbackReceivers.Length; i++)
				{
					callbackReceivers[i].OnPushed();
				}
			}
			SetPoolGuid();
		}

		private void SetPoolGuid()
		{
			Guid guid = Guid.NewGuid();
			IPoolable[] poolables = _poolables;
			for (int i = 0; i < poolables.Length; i++)
			{
				IPoolable poolable2;
				IPoolable poolable = (poolable2 = poolables[i]);
				if (poolable2.PoolGuid == null)
				{
					PoolGuid poolGuid = (poolable2.PoolGuid = new PoolGuid());
				}
				poolable.PoolGuid.Guid = guid;
			}
		}
	}
}
