using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Animancer
{
	public struct FastEnumerator<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly IList<T> List;

		private int _Count;

		private int _Index;

		public int Count
		{
			get
			{
				return _Count;
			}
			set
			{
				_Count = value;
			}
		}

		public int Index
		{
			get
			{
				return _Index;
			}
			set
			{
				_Index = value;
			}
		}

		public T Current
		{
			get
			{
				return List[_Index];
			}
			set
			{
				List[_Index] = value;
			}
		}

		object IEnumerator.Current => Current;

		public T this[int index]
		{
			get
			{
				return List[index];
			}
			set
			{
				List[index] = value;
			}
		}

		public bool IsReadOnly => List.IsReadOnly;

		public FastEnumerator(IList<T> list)
			: this(list, list.Count)
		{
		}

		public FastEnumerator(IList<T> list, int count)
		{
			List = list;
			_Count = count;
			_Index = -1;
		}

		public bool MoveNext()
		{
			_Index++;
			if ((uint)_Index < (uint)_Count)
			{
				return true;
			}
			_Index = int.MinValue;
			return false;
		}

		public bool MovePrevious()
		{
			if (_Index > 0)
			{
				_Index--;
				return true;
			}
			_Index = -1;
			return false;
		}

		public void Reset()
		{
			_Index = -1;
		}

		void IDisposable.Dispose()
		{
		}

		public FastEnumerator<T> GetEnumerator()
		{
			return this;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}

		public int IndexOf(T item)
		{
			return List.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			List.Insert(index, item);
			if (_Index >= index)
			{
				_Index++;
			}
			_Count++;
		}

		public void RemoveAt(int index)
		{
			List.RemoveAt(index);
			if (_Index >= index)
			{
				_Index--;
			}
			_Count--;
		}

		public bool Contains(T item)
		{
			return List.Contains(item);
		}

		public void Add(T item)
		{
			List.Add(item);
			_Count++;
		}

		public bool Remove(T item)
		{
			int num = List.IndexOf(item);
			if (num >= 0)
			{
				RemoveAt(num);
				return true;
			}
			return false;
		}

		public void Clear()
		{
			List.Clear();
			_Index = -1;
			_Count = 0;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 0; i < _Count; i++)
			{
				array[arrayIndex + i] = List[i];
			}
		}

		[Conditional("UNITY_ASSERTIONS")]
		private void AssertIndex(int index)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		private void AssertCount(int count)
		{
		}
	}
}
