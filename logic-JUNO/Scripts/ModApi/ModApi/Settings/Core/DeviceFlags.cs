using System;

namespace ModApi.Settings.Core
{
	[Flags]
	public enum DeviceFlags
	{
		Default = 1,
		Desktop = 2,
		Mobile = 4,
		Android = 8,
		IOS = 0x10,
		Windows = 0x20,
		OSX = 0x40,
		HighEnd = 0x80,
		MidRange = 0x100,
		LowEnd = 0x200,
		HighEndGraphics = 0x400,
		MidRangeGraphics = 0x800,
		LowEndGraphics = 0x1000,
		HighEndProcessor = 0x2000,
		MidRangeProcessor = 0x4000,
		LowEndProcessor = 0x8000,
		LowRam = 0x10000,
		DebugBuild = 0x20000,
		All = -1
	}
}
