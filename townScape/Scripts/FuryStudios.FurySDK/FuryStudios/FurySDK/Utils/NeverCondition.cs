using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class NeverCondition : ICondition
	{
		public bool IsSatisfied()
		{
			return false;
		}
	}
}
