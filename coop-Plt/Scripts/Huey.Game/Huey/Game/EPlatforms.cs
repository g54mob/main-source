using System;

namespace Huey.Game
{
	[Flags]
	internal enum EPlatforms
	{
		None = 1,
		Steam = 2,
		Switch = 4,
		PS4 = 8,
		PS5 = 0x10,
		XboxOne = 0x20,
		XboxSeries = 0x40,
		MicrosoftStore = 0x80
	}
}
