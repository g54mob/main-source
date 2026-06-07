using System;
using System.Collections;
using System.Collections.Generic;

namespace Gilzoide.UpdateManager
{
	public class SortedList<T> : IComparer<T>, IEnumerable<T>, IEnumerable where T : IComparable<T>
	{
		private readonly List<T> _list = new List<T>();

		public int Count => _list.Count;

		public bool Add(T value)
		{
			int num = _list.BinarySearch(value, this);
			if (num < 0)
			{
				_list.Insert(~num, value);
				return true;
			}
			return false;
		}

		public bool Remove(T value)
		{
			int num = _list.BinarySearch(value, this);
			if (num >= 0)
			{
				_list.RemoveAt(num);
				return true;
			}
			return false;
		}

		public bool Contains(T value)
		{
			return _list.BinarySearch(value, this) >= 0;
		}

		public void Clear()
		{
			_list.Clear();
		}

		public List<T>.Enumerator GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public virtual int Compare(T x, T y)
		{
			return x.CompareTo(y);
		}
	}
}
