using System;

namespace NSMedieval.DebugEvents
{
	[Flags]
	public enum ChangedFields : byte
	{
		None = 0,
		Position = 1,
		Goal = 4,
		Health = 8,
		Drafted = 0x10,
		All = byte.MaxValue
	}
}
