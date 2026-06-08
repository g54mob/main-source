using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HandlebarsDotNet.EqualityComparers
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct IntegerEqualityComparer : IEqualityComparer<int>
	{
		public bool Equals(int x, int y)
		{
			return x == y;
		}

		public int GetHashCode(int obj)
		{
			return obj;
		}
	}
}
