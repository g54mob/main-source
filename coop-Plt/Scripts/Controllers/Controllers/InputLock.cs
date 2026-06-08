using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Controllers
{
	public class InputLock
	{
		public readonly struct Lock : IEquatable<Lock>
		{
			public readonly int ID;

			public readonly PlayerLockState Type;

			private static int LockIDIncrement;

			public Lock(PlayerLockState type)
			{
				ID = Interlocked.Increment(ref LockIDIncrement);
				Type = type;
			}

			public bool Equals(Lock other)
			{
				return ID == other.ID;
			}

			public override bool Equals(object obj)
			{
				if (obj is Lock other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return ID;
			}

			public static bool operator ==(Lock left, Lock right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(Lock left, Lock right)
			{
				return !left.Equals(right);
			}
		}

		private List<Lock> Locks = new List<Lock>();

		public bool IsLocked => Locks.Count > 0;

		public PlayerLockState LockState
		{
			get
			{
				int num = 0;
				foreach (Lock @lock in Locks)
				{
					num = Mathf.Max((int)@lock.Type, num);
				}
				return (PlayerLockState)num;
			}
		}

		public bool IsLockedFor(Lock test_lock)
		{
			if (IsLocked)
			{
				return Locks[Locks.Count - 1] != test_lock;
			}
			return false;
		}

		public Lock NewLock(PlayerLockState type)
		{
			Lock obj = new Lock(type);
			Locks.Add(obj);
			return obj;
		}

		public void ReleaseLock(Lock input_lock)
		{
			Locks.Remove(input_lock);
		}

		public bool HasLock(Lock check)
		{
			return Locks.Contains(check);
		}
	}
}
