using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	internal class FuncEqualityComparer<T> : IEqualityComparer<T>
	{
		private readonly Func<T, T, bool> _comparer;

		private readonly Func<T, int> _hash;

		public FuncEqualityComparer(Func<T, T, bool> comparer)
		{
		}

		public FuncEqualityComparer(Func<T, T, bool> comparer, Func<T, int> hash)
		{
		}

		public bool Equals(T x, T y)
		{
			return false;
		}

		public int GetHashCode(T obj)
		{
			return 0;
		}
	}
}
