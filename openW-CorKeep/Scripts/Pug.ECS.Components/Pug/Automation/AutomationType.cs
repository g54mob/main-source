using System;

namespace Pug.Automation
{
	[Flags]
	public enum AutomationType
	{
		None = 0,
		Movee = 1,
		Mover = 2,
		Storage = 4,
		Mineable = 8,
		Miner = 0x10,
		Crafter = 0x20,
		HarvestablePlant = 0x40
	}
}
