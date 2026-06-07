using System.Collections.Generic;

namespace DV.Scenarios
{
	internal class ReferenceEqualsComparer : IEqualityComparer<object>
	{
		public new bool Equals(object x, object y)
		{
			return x == y;
		}

		public int GetHashCode(object obj)
		{
			return obj.GetHashCode();
		}
	}
}
