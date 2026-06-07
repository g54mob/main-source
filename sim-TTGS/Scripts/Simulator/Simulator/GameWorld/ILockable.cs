namespace Simulator.GameWorld
{
	public interface ILockable
	{
		bool IsLocked { get; set; }

		bool CanLock();

		bool CanUnlock();

		void OnLock();

		void OnUnlock();

		bool TryLock()
		{
			if (IsLocked)
			{
				return false;
			}
			if (!CanLock())
			{
				return false;
			}
			Lock();
			return true;
		}

		bool TryUnlock()
		{
			if (!IsLocked)
			{
				return false;
			}
			if (!CanUnlock())
			{
				return false;
			}
			Unlock();
			return true;
		}

		bool TryToggle()
		{
			if (!IsLocked)
			{
				return TryLock();
			}
			return TryUnlock();
		}

		void Lock()
		{
			IsLocked = true;
			OnLock();
		}

		void Unlock()
		{
			IsLocked = false;
			OnUnlock();
		}
	}
}
