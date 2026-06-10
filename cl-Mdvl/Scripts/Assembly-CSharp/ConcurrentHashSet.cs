using System;
using System.Collections;
using System.Collections.Generic;

public class ConcurrentHashSet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly HashSet<T> hashSet;

	public int Count
	{
		get
		{
			lock (hashSet)
			{
				return hashSet.Count;
			}
		}
	}

	public bool IsReadOnly => false;

	public ConcurrentHashSet()
	{
		hashSet = new HashSet<T>();
	}

	public ConcurrentHashSet(int capacity)
	{
		hashSet = new HashSet<T>(capacity);
	}

	public ConcurrentHashSet(IEnumerable<T> values)
	{
		hashSet = new HashSet<T>(values);
	}

	public IEnumerator<T> GetEnumerator()
	{
		lock (hashSet)
		{
			foreach (T item in hashSet)
			{
				yield return item;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	void ICollection<T>.Add(T item)
	{
		lock (hashSet)
		{
			hashSet.Add(item);
		}
	}

	public bool Add(T item)
	{
		lock (hashSet)
		{
			return hashSet.Add(item);
		}
	}

	public void ExceptWith(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			hashSet.ExceptWith(other);
		}
	}

	public void IntersectWith(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			hashSet.IntersectWith(other);
		}
	}

	public bool IsProperSubsetOf(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			return hashSet.IsProperSubsetOf(other);
		}
	}

	public bool IsProperSupersetOf(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			return hashSet.IsProperSupersetOf(other);
		}
	}

	public bool IsSubsetOf(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			return hashSet.IsSubsetOf(other);
		}
	}

	public bool IsSupersetOf(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			return hashSet.IsSupersetOf(other);
		}
	}

	public bool Overlaps(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			return hashSet.Overlaps(other);
		}
	}

	public bool SetEquals(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			return hashSet.SetEquals(other);
		}
	}

	public void SymmetricExceptWith(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			hashSet.SymmetricExceptWith(other);
		}
	}

	public void UnionWith(IEnumerable<T> other)
	{
		lock (hashSet)
		{
			hashSet.UnionWith(other);
		}
	}

	bool ISet<T>.Add(T item)
	{
		lock (hashSet)
		{
			return hashSet.Add(item);
		}
	}

	public void Clear()
	{
		lock (hashSet)
		{
			hashSet.Clear();
		}
	}

	public bool Contains(T item)
	{
		lock (hashSet)
		{
			return hashSet.Contains(item);
		}
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		lock (hashSet)
		{
			hashSet.CopyTo(array, arrayIndex);
		}
	}

	public bool Remove(T item)
	{
		lock (hashSet)
		{
			return hashSet.Remove(item);
		}
	}

	public int RemoveWhere(Predicate<T> predicate)
	{
		lock (hashSet)
		{
			return hashSet.RemoveWhere(predicate);
		}
	}
}
