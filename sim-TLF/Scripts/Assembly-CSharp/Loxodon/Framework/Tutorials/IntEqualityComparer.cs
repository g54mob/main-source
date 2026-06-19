using System.Collections.Generic;

namespace Loxodon.Framework.Tutorials
{
	public class IntEqualityComparer : IEqualityComparer<int>
	{
		public bool Equals(int x, int y)
		{
			return x == y;
		}

		public int GetHashCode(int obj)
		{
			return obj.GetHashCode();
		}
	}
}
