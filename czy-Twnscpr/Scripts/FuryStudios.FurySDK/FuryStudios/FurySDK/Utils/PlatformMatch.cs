using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class PlatformMatch : ICondition
	{
		public PlatformIdentifier platformId;

		public bool IsSatisfied()
		{
			return false;
		}
	}
}
