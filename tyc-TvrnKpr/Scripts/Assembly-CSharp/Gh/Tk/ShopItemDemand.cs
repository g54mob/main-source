using System;

namespace Gh.Tk
{
	[Serializable]
	public enum ShopItemDemand : sbyte
	{
		VeryLow = -2,
		Low = -1,
		Normal = 0,
		High = 1,
		VeryHigh = 2
	}
}
