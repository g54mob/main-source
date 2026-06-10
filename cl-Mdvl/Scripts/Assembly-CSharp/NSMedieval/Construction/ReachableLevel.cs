using System;

namespace NSMedieval.Construction
{
	[Flags]
	public enum ReachableLevel
	{
		None = 0,
		Bottom = 1,
		Middle = 2,
		Top = 4
	}
}
