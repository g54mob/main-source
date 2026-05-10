using System;
using UnityEngine;

namespace CTS.Core
{
	public abstract class LockableMonoBehaviour : MonoBehaviour, ILockable
	{
		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		protected virtual void Awake()
		{
			if (!ObjectLock.IsLocked())
			{
				if (base.isActiveAndEnabled)
				{
					ILockable.ForceEvent(this);
				}
				else
				{
					ILockable.IncrementLock(this);
				}
			}
		}

		protected virtual void OnEnable()
		{
			ILockable.DecrementLock(this);
		}

		protected virtual void OnDisable()
		{
			if (!ObjectLock.IsLocked())
			{
				ILockable.IncrementLock(this);
			}
		}

		void ILockable.OnLocked()
		{
			base.enabled = false;
		}

		void ILockable.OnUnlocked()
		{
			base.enabled = true;
		}
	}
}
