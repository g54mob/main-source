using System;
using System.Collections;
using System.Collections.Generic;
using Gilzoide.UpdateManager.Extensions;

namespace Gilzoide.UpdateManager.Internal
{
	public class FastRemoveList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private FastRemoveList<T> _list;

			public T Current => _list[_list._loopIndex];

			object IEnumerator.Current => Current;

			public Enumerator(FastRemoveList<T> list)
			{
				_list = list;
				Reset();
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (_list._loopIndex < _list.Count - 1)
				{
					_list._loopIndex++;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				_list._loopIndex = -1;
			}
		}

		private readonly List<T> _list = new List<T>();

		private readonly Dictionary<T, int> _indexMap = new Dictionary<T, int>();

		private int _loopIndex;

		public int Count => _list.Count;

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
				{
					return default(T);
				}
				return _list[index];
			}
		}

		public bool Add(T value)
		{
			if (_indexMap.ContainsKey(value))
			{
				return false;
			}
			_list.Add(value);
			_indexMap.Add(value, _list.Count - 1);
			return true;
		}

		public bool Remove(T value)
		{
			if (!_indexMap.TryGetValue(value, out var value2))
			{
				return false;
			}
			_indexMap.Remove(value);
			if (value2 == _loopIndex)
			{
				_loopIndex--;
			}
			else if (value2 < _loopIndex)
			{
				_list.Swap(_loopIndex, value2, out var newDestinationValue);
				_indexMap[newDestinationValue] = value2;
				value2 = _loopIndex;
				_loopIndex--;
			}
			_list.RemoveAtSwapBack(value2, out var swappedValue);
			if (swappedValue != null)
			{
				_indexMap[swappedValue] = value2;
			}
			return true;
		}

		public void Clear()
		{
			_list.Clear();
			_indexMap.Clear();
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
