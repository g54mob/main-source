using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICSharpCode.SharpZipLib.Core
{
	public class NameFilter : IScanFilter
	{
		private string filter_;

		private List<Regex> inclusions_;

		private List<Regex> exclusions_;

		public NameFilter(string filter)
		{
		}

		public static bool IsValidExpression(string expression)
		{
			return false;
		}

		public static bool IsValidFilterExpression(string toTest)
		{
			return false;
		}

		public static string[] SplitQuoted(string original)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public bool IsIncluded(string name)
		{
			return false;
		}

		public bool IsExcluded(string name)
		{
			return false;
		}

		public bool IsMatch(string name)
		{
			return false;
		}

		private void Compile()
		{
		}
	}
}
