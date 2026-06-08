using System.Collections.Generic;

namespace Antlr4.Runtime.Atn
{
	public class ConfigEqualityComparator : IEqualityComparer<ATNConfig>
	{
		public int GetHashCode(ATNConfig o)
		{
			int num = 7;
			num = 31 * num + o.state.stateNumber;
			num = 31 * num + o.alt;
			return 31 * num + o.semanticContext.GetHashCode();
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
			if (a.state.stateNumber == b.state.stateNumber && a.alt == b.alt)
			{
				return a.semanticContext.Equals(b.semanticContext);
			}
			return false;
		}
	}
}
