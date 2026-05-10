using System;

namespace CTS.Core
{
	public interface ILockable
	{
		Lock ObjectLock { get; set; }

		Action<bool> LockStateChanged { get; set; }

		bool IsLocked()
		{
			return ObjectLock.IsLocked();
		}

		bool IsUnlocked()
		{
			return ObjectLock.IsUnlocked();
		}

		internal sealed void IncrementLock()
		{
			SetLockValue(GetLockValue() + 1);
			if (GetLockValue() == 1)
			{
				LockStateChanged?.Invoke(obj: false);
				OnLocked();
			}
		}

		internal static void IncrementLock(ILockable lockable)
		{
			lockable.IncrementLock();
		}

		internal sealed void DecrementLock()
		{
			if (!IsUnlocked())
			{
				SetLockValue(GetLockValue() - 1);
				if (GetLockValue() <= 0)
				{
					SetLockValue(0);
					LockStateChanged?.Invoke(obj: true);
					OnUnlocked();
				}
			}
		}

		internal static void DecrementLock(ILockable lockable)
		{
			lockable.DecrementLock();
		}

		internal static void OnLockableEnable(ILockable lockable)
		{
			lockable.OnLockableEnable();
		}

		internal sealed void OnLockableEnable()
		{
			DecrementLock();
		}

		protected internal void OnLocked();

		protected internal void OnUnlocked();

		internal static void ForceEvent(ILockable lockable)
		{
			lockable.LockStateChanged?.Invoke(lockable.IsUnlocked());
		}

		internal void SetLockValue(int value)
		{
			ObjectLock = new Lock(value);
		}

		internal int GetLockValue()
		{
			return ObjectLock.GetValue();
		}
	}
}
