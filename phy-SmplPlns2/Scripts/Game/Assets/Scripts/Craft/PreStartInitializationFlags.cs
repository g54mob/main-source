using System;

namespace Assets.Scripts.Craft
{
	[Flags]
	public enum PreStartInitializationFlags
	{
		None = 0,
		DefaultScene = 1,
		FlightScene = 2,
		DesignerScene = 4,
		MenuScene = 8,
		StudioScene = 0x10,
		Local = 0x20,
		Remote = 0x40,
		AllScenes = 0x1F,
		NonFlightScenes = 0x1D,
		FlightAndDesignerScene = 6,
		LocalAndRemote = 0x60,
		FlightLocal = 0x22,
		FlightRemote = 0x42,
		FlightDefault = 0x62,
		DesignerDefault = 0x24,
		NonFlightScenesDefault = 0x3D,
		Default = 0x7F
	}
}
