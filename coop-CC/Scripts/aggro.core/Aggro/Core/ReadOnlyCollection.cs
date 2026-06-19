using System.Collections.Generic;

namespace Aggro.Core
{
	public struct ReadOnlyCollection<T>
	{
		private IList<T> _list;

		public int Count => _list.Count;

		public T this[int index] => _list[index];

		public ReadOnlyCollection(IList<T> list)
		{
			_list = list;
		}
	}
}
