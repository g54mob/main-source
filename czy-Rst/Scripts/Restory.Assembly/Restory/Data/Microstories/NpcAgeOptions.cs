using System;

namespace Restory.Data.Microstories
{
	[Flags]
	public enum NpcAgeOptions
	{
		Any = 0,
		Child = 1,
		Teen = 2,
		Adult = 4,
		MiddleAged = 8,
		Elderly = 0x10
	}
}
