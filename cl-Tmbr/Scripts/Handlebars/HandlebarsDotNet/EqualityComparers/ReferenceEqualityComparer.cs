using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HandlebarsDotNet.EqualityComparers
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
	{
		public bool Equals(T x, T y)
		{
			return x == y;
		}

		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}
	}
}
