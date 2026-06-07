using System;

namespace Dhs5.Utility.Updates
{
	[Flags]
	public enum EUpdateChannelFlags
	{
		CLASSIC = 1,
		GAME_PLAYING = 2,
		MOVEMENT = 4,
		SENSORS = 8,
		DAY_CYCLE = 0x10,
		AI = 0x20
	}
}
