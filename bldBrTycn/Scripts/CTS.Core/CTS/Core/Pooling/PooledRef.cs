using System;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Core.Pooling
{
	public readonly struct PooledRef<T> : IEquatable<PooledRef<T>>, IEquatable<T> where T : MonoBehaviour, IPoolable
	{
		private readonly Guid _currentId;

		private readonly T _currentObj;

		public T Value
		{
			get
			{
				if (!IsValid())
				{
					throw new NullReferenceException("Pooled object is null or was returned to the pool and is now a different instance.");
				}
				return _currentObj;
			}
		}

		public PooledRef(T poolable)
		{
			if (poolable.EqualsNull() || poolable.PoolGuid == null || poolable.PoolGuid.Guid == default(Guid))
			{
				_currentObj = null;
				_currentId = default(Guid);
			}
			else
			{
				_currentObj = poolable;
				_currentId = poolable.PoolGuid.Guid;
			}
		}

		public void PushToPool()
		{
			Pooler.Push(_currentObj);
		}

		public bool IsValid()
		{
			if (_currentObj != null)
			{
				return _currentObj.PoolGuid.Guid == _currentId;
			}
			return false;
		}

		public bool TryGetValue(out T outValue)
		{
			if (!IsValid())
			{
				outValue = null;
				return false;
			}
			outValue = _currentObj;
			return true;
		}

		public static implicit operator T(PooledRef<T> pooledRef)
		{
			return pooledRef.Value;
		}

		public static bool operator ==(PooledRef<T> pooledRef, PooledRef<T> pooledRef2)
		{
			return pooledRef.Equals(pooledRef2);
		}

		public static bool operator !=(PooledRef<T> pooledRef, PooledRef<T> pooledRef2)
		{
			return !pooledRef.Equals(pooledRef2);
		}

		public static bool operator ==(PooledRef<T> pooledRef, T pooledRef2)
		{
			return pooledRef.Equals(pooledRef2);
		}

		public static bool operator !=(PooledRef<T> pooledRef, T pooledRef2)
		{
			return !pooledRef.Equals(pooledRef2);
		}

		public static bool operator ==(T pooledRef, PooledRef<T> pooledRef2)
		{
			return pooledRef2.Equals(pooledRef);
		}

		public static bool operator !=(T pooledRef, PooledRef<T> pooledRef2)
		{
			return !pooledRef2.Equals(pooledRef);
		}

		public bool Equals(PooledRef<T> other)
		{
			if (other._currentId == _currentId)
			{
				return other._currentObj == _currentObj;
			}
			return false;
		}

		public bool Equals(T other)
		{
			if ((object)other == null)
			{
				return (object)_currentObj == null;
			}
			if (other == _currentObj)
			{
				return other.PoolGuid.Guid == _currentId;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is PooledRef<T> other))
			{
				if (obj is T other2)
				{
					return Equals(other2);
				}
				return false;
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return _currentId.GetHashCode();
		}
	}
}
