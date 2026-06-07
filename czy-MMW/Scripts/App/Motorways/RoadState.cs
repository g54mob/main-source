using System;

namespace Motorways
{
	[Flags]
	public enum RoadState
	{
		None = 0,
		Planned = 2,
		Pending = 4,
		Active = 8,
		Mothballed = 0x10,
		Live = 0x18,
		VisiblyActive = 0xE,
		ActiveOrPending = 0xC
	}
}
