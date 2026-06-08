using System;

namespace LaundryBear.PlatformServices
{
	[Flags]
	public enum Platform
	{
		None = 0,
		Windows = 1,
		MacOS = 2,
		Switch = 4,
		GameCoreXboxSeries = 8,
		GameCoreXboxOne = 0x10,
		GameCoreWindows = 0x20,
		PS4 = 0x40,
		PS5 = 0x80,
		Android = 0x100,
		iOS = 0x200,
		Desktop = 3,
		GameCoreConsole = 0x18,
		GameCore = 0x38,
		PlayStation = 0xC0,
		Console = 0xFC,
		Mobile = 0x300
	}
}
