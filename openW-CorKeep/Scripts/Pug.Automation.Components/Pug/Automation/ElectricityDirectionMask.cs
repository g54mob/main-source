using System;

namespace Pug.Automation
{
	[Flags]
	public enum ElectricityDirectionMask
	{
		None = 0,
		East = 1,
		North = 2,
		South = 4,
		West = 8,
		All = 0xF
	}
}
