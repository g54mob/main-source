using System;

namespace Assets.Scripts.Craft
{
	[Flags]
	public enum CraftUpdateFlags
	{
		None = 0,
		DefaultScene = 1,
		FlightScene = 2,
		DesignerScene = 4,
		MenuScene = 8,
		StudioScene = 0x10,
		Local = 0x20,
		Remote = 0x40,
		Unpaused = 0x80,
		Paused = 0x100,
		AllScenes = 0x1F,
		NonFlightScenes = 0x1D,
		FlightAndDesignerScene = 6,
		LocalAndRemote = 0x60,
		FlightUnpaused = 0xE2,
		FlightLocal = 0x1A2,
		FlightLocalUnpaused = 0xA2,
		FlightRemoteUnpaused = 0xC2,
		FlightDefault = 0x1E2,
		DesignerDefault = 0x1A4,
		NonFlightScenesDefault = 0x1BD,
		Default = 0x1FF
	}
}
