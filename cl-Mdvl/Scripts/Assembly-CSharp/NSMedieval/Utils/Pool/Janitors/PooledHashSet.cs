using System;
using System.Collections;
using System.Collections.Generic;

namespace NSMedieval.Utils.Pool.Janitors
{
	public readonly struct PooledHashSet<T> : IDisposable, IEnumerable<T>, IEnumerable, ISet<T>, ICollection<T>
	{
		private readonly HashSet<T> hashSet;

		public int Count => hashSet.Count;

		public bool IsReadOnly => false;

		public bool Remove(T item)
		{
			return hashSet.Remove(item);
		}

		public PooledHashSet(HashSet<T> hashSet)
		{
			this.hashSet = hashSet;
		}

		public void Dispose()
		{
			HashSetPool<T>.Return(hashSet);
		}

		public HashSet<T>.Enumerator GetEnumerator()
		{
			return hashSet.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return hashSet.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return hashSet.GetEnumerator();
		}

		void ICollection<T>.Add(T item)
		{
			hashSet.Add(item);
		}

		public void ExceptWith(IEnumerable<T> other)
		{
			hashSet.ExceptWith(other);
		}

		public void IntersectWith(IEnumerable<T> other)
		{
			hashSet.IntersectWith(other);
		}

		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			return hashSet.IsProperSubsetOf(other);
		}

		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			return hashSet.IsProperSupersetOf(other);
		}

		public bool IsSubsetOf(IEnumerable<T> other)
		{
			return hashSet.IsSubsetOf(other);
		}

		public bool IsSupersetOf(IEnumerable<T> other)
		{
			return hashSet.IsSupersetOf(other);
		}

		public bool Overlaps(IEnumerable<T> other)
		{
			return hashSet.Overlaps(other);
		}

		public bool SetEquals(IEnumerable<T> other)
		{
			return hashSet.SetEquals(other);
		}

		public void SymmetricExceptWith(IEnumerable<T> other)
		{
			hashSet.SymmetricExceptWith(other);
		}

		public void UnionWith(IEnumerable<T> other)
		{
			hashSet.UnionWith(other);
		}

		public void Clear()
		{
			hashSet.Clear();
		}

		public bool Add(T obj)
		{
			return hashSet.Add(obj);
		}

		public bool Contains(T obj)
		{
			return hashSet.Contains(obj);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			hashSet.CopyTo(array, arrayIndex);
		}

		public void UnionWith(HashSet<T> other)
		{
			if (other != null)
			{
				hashSet.UnionWith(other);
			}
		}
	}
}
