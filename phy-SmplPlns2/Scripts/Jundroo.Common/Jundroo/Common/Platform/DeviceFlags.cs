using System;

namespace Jundroo.Common.Platform
{
	[Flags]
	public enum DeviceFlags
	{
		Default = 1,
		Desktop = 2,
		Mobile = 4,
		SteamDeck = 8,
		Android = 0x10,
		IOS = 0x20,
		Windows = 0x40,
		OSX = 0x80,
		HighEnd = 0x100,
		MidRange = 0x200,
		LowEnd = 0x400,
		HighEndGraphics = 0x800,
		MidRangeGraphics = 0x1000,
		LowEndGraphics = 0x2000,
		HighEndProcessor = 0x4000,
		MidRangeProcessor = 0x8000,
		LowEndProcessor = 0x10000,
		LowRam = 0x20000,
		DebugBuild = 0x40000,
		All = -1
	}
}
