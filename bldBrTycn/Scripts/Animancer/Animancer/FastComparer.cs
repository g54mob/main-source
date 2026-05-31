using System.Collections.Generic;

namespace Animancer
{
	public sealed class FastComparer : IEqualityComparer<object>
	{
		public static readonly FastComparer Instance = new FastComparer();

		bool IEqualityComparer<object>.Equals(object x, object y)
		{
			return object.Equals(x, y);
		}

		int IEqualityComparer<object>.GetHashCode(object obj)
		{
			return obj.GetHashCode();
		}
	}
}
