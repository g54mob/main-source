using System.Collections.Generic;

namespace Antlr4.Runtime.Atn
{
	public class ObjectEqualityComparator : IEqualityComparer<ATNConfig>
	{
		public int GetHashCode(ATNConfig o)
		{
			return o?.GetHashCode() ?? 0;
		}

		public bool Equals(ATNConfig a, ATNConfig b)
		{
			if (a == b)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			return a.Equals(b);
		}
	}
}
