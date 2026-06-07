using System.Collections.Generic;
using System.Text;

namespace ShellFileDialogs
{
	public class Filter
	{
		private static readonly char[] _semiColon;

		private static readonly char[] _pipe;

		public string DisplayName { get; }

		public IReadOnlyList<string> Extensions { get; }

		public Filter(string displayName, params string[] extensions)
		{
		}

		public Filter(string displayName, IEnumerable<string> extensions)
		{
		}

		public static IReadOnlyList<Filter> ParseWindowsFormsFilter(string filter)
		{
			return null;
		}

		internal string ToFilterSpecString()
		{
			return null;
		}

		internal void ToExtensionList(StringBuilder sb)
		{
		}

		public override string ToString()
		{
			return null;
		}

		internal FilterSpec ToFilterSpec()
		{
			return default(FilterSpec);
		}
	}
}
