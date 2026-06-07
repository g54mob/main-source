using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class FeatureMatch : ICondition
	{
		public PlatformFeature features;

		public MatchMode match;

		public bool IsSatisfied()
		{
			return false;
		}
	}
}
