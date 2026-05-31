using System;
using CTS.Core;

namespace CTS
{
	public class SimpleToggle : ILockable
	{
		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public bool IsLocked => ObjectLock.IsLocked();

		public bool IsUnlocked => ObjectLock.IsUnlocked();

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
