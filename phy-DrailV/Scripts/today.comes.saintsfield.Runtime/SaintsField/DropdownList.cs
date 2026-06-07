using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SaintsField.DropdownBase;

namespace SaintsField
{
	public class DropdownList<T> : IDropdownList, IEnumerable<(string, object, bool, bool)>, IEnumerable
	{
		private readonly List<(string, object, bool, bool)> _values;

		public DropdownList()
		{
			_values = new List<(string, object, bool, bool)>();
		}

		public DropdownList(IEnumerable<(string, T)> value)
		{
			_values = value.Select(((string, T) each) => ((string, object, bool, bool))(each.Item1, each.Item2, false, false)).ToList();
		}

		public DropdownList(IEnumerable<(string, T, bool)> value)
		{
			_values = value.Select(((string, T, bool) each) => ((string, object, bool, bool))(each.Item1, each.Item2, each.Item3, false)).ToList();
		}

		public void Add(string displayName, T value)
		{
			_values.Add((displayName, value, false, false));
		}

		public void Add(string displayName, T value, bool disabled)
		{
			_values.Add((displayName, value, disabled, false));
		}

		public void Add((string, object, bool, bool) tuple)
		{
			_values.Add(tuple);
		}

		public void AddSeparator(string separator = "")
		{
			_values.Add((separator, null, false, true));
		}

		public static (string, object, bool, bool) Separator(string separatorPath = "")
		{
			return (separatorPath, null, false, true);
		}

		public static (string, object, bool, bool) Item(string name, T item)
		{
			return (name, item, false, false);
		}

		public static (string, object, bool, bool) Item(string name, T item, bool disabled)
		{
			return (name, item, disabled, false);
		}

		public void AddRange(IEnumerable<(string, T, bool, bool)> pairs)
		{
			foreach (var pair in pairs)
			{
				List<(string, object, bool, bool)> values = _values;
				(string, T, bool, bool) tuple = pair;
				values.Add((tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4));
			}
		}

		public void AddRange(IEnumerable<(string, T)> pairs)
		{
			AddRange(pairs.Select(((string, T) each) => (each.Item1, each.Item2, false, false)));
		}

		public void AddRange(IEnumerable<(string, T, bool)> pairs)
		{
			AddRange(pairs.Select(((string, T, bool) each) => (each.Item1, each.Item2, each.Item3, false)));
		}

		public IEnumerator<(string, object, bool, bool)> GetEnumerator()
		{
			return _values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
