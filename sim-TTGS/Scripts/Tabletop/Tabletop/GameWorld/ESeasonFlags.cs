using System;

namespace Tabletop.GameWorld
{
	[Flags]
	public enum ESeasonFlags
	{
		SEASON1 = 1,
		SEASON2 = 2,
		SEASON3 = 4,
		SEASON4 = 8,
		SEASON5 = 0x10
	}
}
