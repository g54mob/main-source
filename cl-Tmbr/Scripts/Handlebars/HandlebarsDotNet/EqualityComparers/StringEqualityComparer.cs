using System;
using System.Collections.Generic;

namespace HandlebarsDotNet.EqualityComparers
{
	internal readonly struct StringEqualityComparer : IEqualityComparer<string>
	{
		private readonly StringComparison _stringComparison;

		public StringEqualityComparer(StringComparison stringComparison)
		{
			_stringComparison = stringComparison;
		}

		public bool Equals(string x, string y)
		{
			return string.Equals(x, y, _stringComparison);
		}

		public int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}
	}
}
