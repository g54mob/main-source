using System.Collections;
using System.Collections.Generic;

namespace Jundroo.Common.Collections
{
	public class CircularList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		private IEqualityComparer<T> _equalityComparer;

		private List<T> _list;

		private bool _usesDefaultEqualityComparer;

		public int Count => _list.Count;

		public IEqualityComparer<T> EqualityComparer => _equalityComparer;

		bool ICollection<T>.IsReadOnly => false;

		public T this[int index]
		{
			get
			{
				return _list[index];
			}
			set
			{
				_list[index] = value;
			}
		}

		public CircularList()
		{
			_list = new List<T>();
			_equalityComparer = EqualityComparer<T>.Default;
			_usesDefaultEqualityComparer = true;
		}

		public CircularList(IEqualityComparer<T> equalityComparer)
		{
			_list = new List<T>();
			_equalityComparer = equalityComparer;
			_usesDefaultEqualityComparer = equalityComparer == EqualityComparer<T>.Default;
		}

		public void Add(T item)
		{
			_list.Add(item);
		}

		public void AddRange(IEnumerable<T> collection)
		{
			_list.AddRange(collection);
		}

		public void Clear()
		{
			_list.Clear();
		}

		public bool Contains(T item)
		{
			if (_usesDefaultEqualityComparer)
			{
				return _list.Contains(item);
			}
			if (item == null)
			{
				for (int i = 0; i < _list.Count; i++)
				{
					if (_list[i] == null)
					{
						return true;
					}
				}
				return false;
			}
			IEqualityComparer<T> equalityComparer = _equalityComparer;
			for (int j = 0; j < _list.Count; j++)
			{
				if (equalityComparer.Equals(_list[j], item))
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public int GetIndexOfValue(T v)
		{
			for (int i = 0; i < _list.Count; i++)
			{
				if (_equalityComparer.Equals(_list[i], v))
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOf(T item)
		{
			if (_usesDefaultEqualityComparer)
			{
				return _list.IndexOf(item);
			}
			for (int i = 0; i < _list.Count; i++)
			{
				if (_equalityComparer.Equals(_list[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			_list.Insert(index, item);
		}

		public T NextValue(T currentValue)
		{
			int num = 0;
			for (int i = 0; i < _list.Count; i++)
			{
				if (_equalityComparer.Equals(_list[i], currentValue))
				{
					num = i + 1;
					break;
				}
			}
			if (num >= _list.Count)
			{
				num = 0;
			}
			return _list[num];
		}

		public T PreviousValue(T currentValue)
		{
			int num = 0;
			for (int i = 0; i < _list.Count; i++)
			{
				if (_equalityComparer.Equals(_list[i], currentValue))
				{
					num = i - 1;
					break;
				}
			}
			if (num < 0)
			{
				num = _list.Count - 1;
			}
			return _list[num];
		}

		public bool Remove(T item)
		{
			if (_usesDefaultEqualityComparer)
			{
				return _list.Remove(item);
			}
			int num = IndexOf(item);
			if (num >= 0)
			{
				RemoveAt(num);
				return true;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			_list.RemoveAt(index);
		}
	}
}
