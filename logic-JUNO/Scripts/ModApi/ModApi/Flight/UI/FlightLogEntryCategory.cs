using System;

namespace ModApi.Flight.UI
{
	[Flags]
	public enum FlightLogEntryCategory
	{
		Default = 0,
		CraftDamage = 1,
		Vizzy = 2,
		All = 3
	}
}
