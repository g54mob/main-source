using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PercentageWithLabel : TPercentage
	{
		public PercentageWithLabel()
		{
		}

		public PercentageWithLabel(float unit)
			: base(unit)
		{
		}
	}
}
