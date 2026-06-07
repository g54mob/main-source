using System;

namespace Motorways.Processes
{
	[Flags]
	public enum DisabledUpgradeOptions
	{
		None = 0,
		Option1 = 2,
		Option2 = 4,
		Option3 = 8,
		Option4 = 0x10,
		Option5 = 0x20,
		Option6 = 0x40
	}
}
