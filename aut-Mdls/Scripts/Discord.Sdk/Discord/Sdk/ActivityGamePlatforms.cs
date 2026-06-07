using System;

namespace Discord.Sdk
{
	[Flags]
	public enum ActivityGamePlatforms
	{
		Desktop = 1,
		Xbox = 2,
		Samsung = 4,
		IOS = 8,
		Android = 0x10,
		Embedded = 0x20,
		PS4 = 0x40,
		PS5 = 0x80
	}
}
