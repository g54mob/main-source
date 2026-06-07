using System;

namespace FuryStudios.FurySDK
{
	[Flags]
	public enum SystemIdentifier : uint
	{
		Unknown = 0u,
		PC = 1u,
		Windows = 2u,
		MacOS = 4u,
		Linux = 8u,
		Mobile = 0x10u,
		Android = 0x20u,
		IOS = 0x40u,
		Console = 0x80u,
		XboxOneFamily = 0x100u,
		XboxOne = 0x2000u,
		XboxOneS = 0x4000u,
		XboxOneX = 0x8000u,
		XboxSeriesFamily = 0x200u,
		XboxSeriesS = 0x10000u,
		XboxSeriesX = 0x20000u,
		PS4 = 0x400u,
		PS5 = 0x800u,
		Switch = 0x1000u
	}
}
