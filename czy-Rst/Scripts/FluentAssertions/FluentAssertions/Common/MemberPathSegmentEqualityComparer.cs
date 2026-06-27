using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FluentAssertions.Common
{
	internal class MemberPathSegmentEqualityComparer : IEqualityComparer<string>
	{
		private const string AnyIndexQualifier = "*";

		private static readonly Regex IndexQualifierRegex = new Regex("^[0-9]+$");

		public bool Equals(string x, string y)
		{
			if (x == "*")
			{
				return IsIndexQualifier(y);
			}
			if (y == "*")
			{
				return IsIndexQualifier(x);
			}
			return x == y;
		}

		private static bool IsIndexQualifier(string segment)
		{
			if (!(segment == "*"))
			{
				return IndexQualifierRegex.IsMatch(segment);
			}
			return true;
		}

		public int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}
	}
}
