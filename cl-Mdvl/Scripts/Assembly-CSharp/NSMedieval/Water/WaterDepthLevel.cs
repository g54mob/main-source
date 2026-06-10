using System;

namespace NSMedieval.Water
{
	[Flags]
	public enum WaterDepthLevel
	{
		None = 1,
		Low = 2,
		Medium = 4,
		High = 8
	}
}
