using System;
using System.Collections.Generic;

namespace Castle.Core.Internal
{
	internal class WeakKeyComparer<TKey> : IEqualityComparer<object> where TKey : class
	{
		public static readonly WeakKeyComparer<TKey> Default = new WeakKeyComparer<TKey>(EqualityComparer<TKey>.Default);

		private readonly IEqualityComparer<TKey> comparer;

		public WeakKeyComparer(IEqualityComparer<TKey> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			this.comparer = comparer;
		}

		public object Wrap(TKey key)
		{
			return new WeakKey(key, comparer.GetHashCode(key));
		}

		public TKey Unwrap(object obj)
		{
			if (!(obj is WeakKey weakKey))
			{
				return (TKey)obj;
			}
			return (TKey)weakKey.Target;
		}

		public int GetHashCode(object obj)
		{
			if (!(obj is WeakKey weakKey))
			{
				return comparer.GetHashCode((TKey)obj);
			}
			return weakKey.GetHashCode();
		}

		public new bool Equals(object objA, object objB)
		{
			TKey val = Unwrap(objA);
			TKey val2 = Unwrap(objB);
			if (val == null)
			{
				if (val2 == null)
				{
					return objA == objB;
				}
				return false;
			}
			if (val2 == null)
			{
				return false;
			}
			return comparer.Equals(val, val2);
		}
	}
}
