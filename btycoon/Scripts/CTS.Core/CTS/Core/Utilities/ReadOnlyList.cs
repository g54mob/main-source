using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.Core.Utilities
{
	public readonly struct ReadOnlyList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IEquatable<List<T>>, IEquatable<ReadOnlyList<T>>, IEnumerable<T, List<T>.Enumerator>
	{
		private readonly List<T> _list;

		public int Count => _list.Count;

		public T this[int index] => _list[index];

		public T this[Index index]
		{
			get
			{
				List<T> list = _list;
				return list[index.GetOffset(list.Count)];
			}
		}

		public ReadOnlyList(List<T> list)
		{
			_list = list;
		}

		public static implicit operator ReadOnlyList<T>(List<T> list)
		{
			return new ReadOnlyList<T>(list);
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

		public bool Contains(T obj)
		{
			return _list.Contains(obj);
		}

		public List<T> Copy()
		{
			return new List<T>(_list);
		}

		public static bool operator ==(ReadOnlyList<T> list, List<T> otherList)
		{
			return list.Equals(otherList);
		}

		public static bool operator !=(ReadOnlyList<T> list, List<T> otherList)
		{
			return !list.Equals(otherList);
		}

		public static bool operator ==(ReadOnlyList<T> list, ReadOnlyList<T> otherList)
		{
			return list.Equals(otherList);
		}

		public static bool operator !=(ReadOnlyList<T> list, ReadOnlyList<T> otherList)
		{
			return !list.Equals(otherList);
		}

		public static bool operator ==(List<T> list, ReadOnlyList<T> otherList)
		{
			return otherList.Equals(list);
		}

		public static bool operator !=(List<T> list, ReadOnlyList<T> otherList)
		{
			return !otherList.Equals(list);
		}

		public bool Equals(List<T> other)
		{
			if (_list == null)
			{
				return other == null;
			}
			return _list.Equals(other);
		}

		public bool Equals(ReadOnlyList<T> other)
		{
			return Equals(other._list);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is List<T> other))
			{
				if (obj is ReadOnlyList<T> other2)
				{
					return Equals(other2);
				}
				return false;
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return _list.GetHashCode();
		}
	}
}
