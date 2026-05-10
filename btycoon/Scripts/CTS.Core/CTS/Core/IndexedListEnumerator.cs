using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.Core
{
	public readonly struct IndexedListEnumerator<T> : IEnumerable<T, IndexedListEnumerator<T>.Enumerator>, IEnumerable<T>, IEnumerable
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private readonly List<T> _list;

			private int _index;

			public T Current { get; private set; }

			object IEnumerator.Current => Current;

			public Enumerator(List<T> list, int startIndex)
			{
				_list = list;
				_index = startIndex;
				Current = default(T);
			}

			public bool MoveNext()
			{
				if (_index >= _list.Count)
				{
					return false;
				}
				Current = _list[_index];
				_index++;
				return true;
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		private readonly List<T> _list;

		private readonly int _startIndex;

		public IndexedListEnumerator(List<T> list, int startIndex)
		{
			_list = list;
			_startIndex = startIndex;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_list, _startIndex);
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
