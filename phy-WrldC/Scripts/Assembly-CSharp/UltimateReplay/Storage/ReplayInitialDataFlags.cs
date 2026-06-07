using System;

namespace UltimateReplay.Storage
{
	[Flags]
	public enum ReplayInitialDataFlags : byte
	{
		None = 0,
		Position = 1,
		Rotation = 2,
		Scale = 4,
		Parent = 8
	}
}
