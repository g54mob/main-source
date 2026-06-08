using System;

namespace KitchenData
{
	[Flags]
	public enum DisplayedPatienceFactor
	{
		None = 0,
		PlayerInView = 1,
		PlayerNearby = 2
	}
}
