using System.Collections;
using System.Collections.Generic;

namespace CTS.Core
{
	public readonly struct ListEnumerator<T> : IEnumerable<T, List<T>.Enumerator>, IEnumerable<T>, IEnumerable
	{
		private readonly List<T> _list;

		public ListEnumerator(List<T> list)
		{
			_list = list;
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
	}
}
