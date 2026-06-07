using System.Collections.Generic;

namespace ModApi.Common.Collections
{
	public class CircularList<T>
	{
		private List<T> _list;

		public int Count => _list.Count;

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
		}

		public void Add(T value)
		{
			_list.Add(value);
		}

		public void Clear()
		{
			_list.Clear();
		}

		public bool Contains(T value)
		{
			return _list.Contains(value);
		}

		public int GetIndexOfValue(T v)
		{
			for (int i = 0; i < _list.Count; i++)
			{
				if (Compare(_list[i], v))
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
				if (Compare(_list[i], currentValue))
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
				if (Compare(_list[i], currentValue))
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

		public void Remove(T value)
		{
			_list.Remove(value);
		}

		public void RemoveAt(int index)
		{
			_list.RemoveAt(index);
		}

		private static bool Compare(T x, T y)
		{
			return EqualityComparer<T>.Default.Equals(x, y);
		}
	}
}
