using System.Collections.Generic;

namespace Gh.Tk
{
	public class LarderSetting : IPersistable
	{
		public string ItemKey;

		public int TargetAmount;

		public bool Suspended;

		public bool HighPriority;

		public IEnumerable<string> GetIssues()
		{
			return null;
		}
	}
}
