using System.Collections.Generic;

namespace Animancer
{
	public sealed class FastReferenceComparer : IEqualityComparer<object>
	{
		public static readonly FastReferenceComparer Instance = new FastReferenceComparer();

		bool IEqualityComparer<object>.Equals(object x, object y)
		{
			return x == y;
		}

		int IEqualityComparer<object>.GetHashCode(object obj)
		{
			return obj.GetHashCode();
		}
	}
}
