using System;
using System.Collections;
using System.Collections.Generic;

namespace CTS.Core
{
	public readonly struct IndexedArrayEnumerator<T> : IEnumerable<T, IndexedArrayEnumerator<T>.Enumerator>, IEnumerable<T>, IEnumerable
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private readonly T[] _array;

			private int _index;

			public T Current => _array[_index];

			object IEnumerator.Current => Current;

			public Enumerator(T[] array, int startIndex)
			{
				_array = array;
				_index = startIndex - 1;
			}

			public bool MoveNext()
			{
				_index++;
				return _index < _array.Length;
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		private readonly T[] _array;

		private readonly int _startIndex;

		public IndexedArrayEnumerator(T[] array, int startIndex)
		{
			_array = array;
			_startIndex = startIndex;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(_array, _startIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
