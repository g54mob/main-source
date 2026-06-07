using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class OrConditions : GroupConditions
	{
		public override bool IsSatisfied()
		{
			return false;
		}
	}
}
