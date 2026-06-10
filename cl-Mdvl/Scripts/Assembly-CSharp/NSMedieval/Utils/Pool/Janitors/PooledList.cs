using System;
using System.Collections;
using System.Collections.Generic;
using NSEipix;

namespace NSMedieval.Utils.Pool.Janitors
{
	public readonly struct PooledList<T> : IDisposable, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		private readonly List<T> list;

		public int Count => list?.Count ?? 0;

		public bool IsReadOnly => ((ICollection<T>)list).IsReadOnly;

		public bool HasValue => list != null;

		public T this[int index]
		{
			get
			{
				return list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		public PooledList(List<T> list)
		{
			this.list = list;
		}

		public List<T> GetRawList()
		{
			return list;
		}

		public void Dispose()
		{
			if (list != null)
			{
				ListPool<T>.Return(list);
			}
		}

		public List<T>.Enumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public void Add(T item)
		{
			list.Add(item);
		}

		public void AddIfNotNull(T item)
		{
			if (item != null)
			{
				list.Add(item);
			}
		}

		public void AddRange(IEnumerable<T> collection)
		{
			list.AddRange(collection);
		}

		public void Clear()
		{
			list.Clear();
		}

		public bool Contains(T item)
		{
			return list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return list.Remove(item);
		}

		public void RemoveRange(int index, int count)
		{
			list.RemoveRange(index, count);
		}

		public int IndexOf(T item)
		{
			return list.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			list.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public void Sort(Comparison<T> comparison)
		{
			list.Sort(comparison);
		}

		public void RemoveWhere(Func<T, bool> predicate)
		{
			list.RemoveWhere(predicate);
		}

		public int FindIndex(Predicate<T> predicate)
		{
			return list.FindIndex(predicate);
		}
	}
}
