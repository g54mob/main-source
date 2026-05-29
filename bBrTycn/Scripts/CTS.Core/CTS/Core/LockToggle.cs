using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public class LockToggle
	{
		private readonly List<ILockable> _lockables = new List<ILockable>();

		private static readonly Queue<LockToggle> _wrappers = new Queue<LockToggle>();

		public bool Locked { get; private set; }

		public LockToggle()
		{
		}

		public LockToggle(params ILockable[] lockables)
		{
			_lockables.AddRange(lockables);
		}

		~LockToggle()
		{
			Unlock();
		}

		public void Add(ILockable lockable)
		{
			if (!_lockables.Contains(lockable))
			{
				_lockables.Add(lockable);
				if (Locked)
				{
					lockable.IncrementLock();
				}
			}
		}

		public void Remove(ILockable lockable)
		{
			if (_lockables.Contains(lockable))
			{
				if (Locked)
				{
					lockable.DecrementLock();
				}
				_lockables.Remove(lockable);
			}
		}

		public void Set(params ILockable[] lockables)
		{
			if (Locked)
			{
				Unlock();
			}
			_lockables.Clear();
			_lockables.AddRange(lockables);
			if (Locked)
			{
				Lock();
			}
		}

		public void Clear()
		{
			bool locked = Locked;
			if (locked)
			{
				Unlock();
			}
			_lockables.Clear();
			if (locked)
			{
				Lock();
			}
		}

		public void Lock()
		{
			if (Locked)
			{
				return;
			}
			Locked = true;
			if (_lockables == null)
			{
				return;
			}
			foreach (ILockable lockable in _lockables)
			{
				if (lockable != null && (!(lockable is MonoBehaviour monoBehaviour) || !(monoBehaviour == null)))
				{
					lockable.IncrementLock();
				}
			}
		}

		public void Unlock()
		{
			if (!Locked)
			{
				return;
			}
			Locked = false;
			if (_lockables == null)
			{
				return;
			}
			foreach (ILockable lockable in _lockables)
			{
				if (lockable != null && (!(lockable is MonoBehaviour monoBehaviour) || !(monoBehaviour == null)))
				{
					lockable.DecrementLock();
				}
			}
		}

		public void SetLock(bool locked)
		{
			if (locked)
			{
				Lock();
			}
			else
			{
				Unlock();
			}
		}

		public static LockToggle Get(params ILockable[] toggleables)
		{
			if (_wrappers.TryDequeue(out var result))
			{
				result.Set(toggleables);
				return result;
			}
			return new LockToggle(toggleables);
		}

		public void Dispose()
		{
			Unlock();
			_lockables.Clear();
			_wrappers.Enqueue(this);
		}
	}
}
