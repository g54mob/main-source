using System;

namespace FuryStudios.FurySDK.Utils
{
	[Serializable]
	public class AlwaysCondition : ICondition
	{
		public bool IsSatisfied()
		{
			return false;
		}
	}
}
