using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class SystemMatch : ICondition
	{
		public SystemIdentifier systemId;

		public MatchMode match;

		public bool IsSatisfied()
		{
			return false;
		}
	}
}
