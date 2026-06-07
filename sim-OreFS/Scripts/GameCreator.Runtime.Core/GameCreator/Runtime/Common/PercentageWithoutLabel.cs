using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PercentageWithoutLabel : TPercentage
	{
		public PercentageWithoutLabel()
		{
		}

		public PercentageWithoutLabel(float unit)
			: base(unit)
		{
		}
	}
}
