using System.Collections;
using System.Collections.Generic;

namespace CTS.Core
{
	public readonly struct HashSetEnumerator<T> : IEnumerable<T, HashSet<T>.Enumerator>, IEnumerable<T>, IEnumerable
	{
		private readonly HashSet<T> _hashSet;

		public HashSetEnumerator(HashSet<T> hashSet)
		{
			_hashSet = hashSet;
		}

		public HashSet<T>.Enumerator GetEnumerator()
		{
			return _hashSet.GetEnumerator();
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
