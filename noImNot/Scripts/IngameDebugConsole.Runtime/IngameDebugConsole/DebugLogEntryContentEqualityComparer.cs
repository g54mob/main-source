using System.Collections.Generic;

namespace IngameDebugConsole
{
	public class DebugLogEntryContentEqualityComparer : EqualityComparer<DebugLogEntry>
	{
		public override bool Equals(DebugLogEntry x, DebugLogEntry y)
		{
			return false;
		}

		public override int GetHashCode(DebugLogEntry obj)
		{
			return 0;
		}
	}
}
