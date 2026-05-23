using System;
using System.Collections;
using System.Collections.Generic;

namespace Pathfinding.RVO
{
	public struct IReadOnlySlice<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
	{
		public T[] data;

		public int length;

		public T this[int index] => data[index];

		public int Count => length;

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
