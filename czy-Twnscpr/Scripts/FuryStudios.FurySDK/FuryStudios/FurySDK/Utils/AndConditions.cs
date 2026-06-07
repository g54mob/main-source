using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class AndConditions : GroupConditions
	{
		public override bool IsSatisfied()
		{
			return false;
		}
	}
}
