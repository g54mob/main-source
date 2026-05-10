using System.Collections;
using System.Collections.Generic;

namespace NaughtyAttributes
{
	public class DropdownList<T> : IDropdownList, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		private List<KeyValuePair<string, object>> _values;

		public void Add(string displayName, T value)
		{
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public static explicit operator DropdownList<object>(DropdownList<T> target)
		{
			return null;
		}
	}
}
