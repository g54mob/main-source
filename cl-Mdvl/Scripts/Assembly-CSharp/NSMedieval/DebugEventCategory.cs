using System;

namespace NSMedieval
{
	[Flags]
	public enum DebugEventCategory
	{
		Event = 1,
		StateChange = 2,
		HiddenEvent = 4
	}
}
