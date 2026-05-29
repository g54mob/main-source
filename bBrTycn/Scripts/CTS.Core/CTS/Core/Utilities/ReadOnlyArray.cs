using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CTS.Core.Utilities
{
	public readonly struct ReadOnlyArray<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IEnumerable<T, IndexedArrayEnumerator<T>.Enumerator>
	{
		private readonly T[] _array;

		public int Count => _array.Length;

		public int Length => _array.Length;

		public T this[int index] => _array[index];

		public T this[Index index] => _array[index];

		public T[] this[Range range] => _array[range];

		public ReadOnlyArray(T[] array)
		{
			_array = array;
		}

		public static implicit operator ReadOnlyArray<T>(T[] list)
		{
			return new ReadOnlyArray<T>(list);
		}

		public IndexedArrayEnumerator<T>.Enumerator GetEnumerator()
		{
			return new IndexedArrayEnumerator<T>.Enumerator(_array, 0);
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
			return _array.Contains(obj);
		}
	}
}
