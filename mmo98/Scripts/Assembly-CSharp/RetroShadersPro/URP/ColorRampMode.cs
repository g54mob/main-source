using UnityEngine;

namespace RetroShadersPro.URP
{
	public enum ColorRampMode
	{
		None = 0,
		[InspectorName("Game and Watch")]
		GameAndWatch = 1,
		[InspectorName("Game Boy")]
		GB = 2,
		[InspectorName("Game Boy Advance")]
		GBA = 3,
		[InspectorName("Nintendo DS")]
		DS = 4,
		Greyscale = 5,
		NES = 6,
		SNES = 7,
		MSX2 = 8,
		[InspectorName("IBM PS-2")]
		IBMPS2 = 9,
		[InspectorName("Amstrad CPC")]
		Amstrad = 10,
		Teletext = 11,
		[InspectorName("ZX Spectrum")]
		ZXSpectrum = 12,
		[InspectorName("Sega Master System")]
		MasterSystem = 13,
		[InspectorName("Sega Genesis")]
		Genesis = 14,
		[InspectorName("Sega Game Gear")]
		GameGear = 15,
		[InspectorName("Custom Luminance")]
		CustomLuminance = 16,
		[InspectorName("Custom RGB")]
		CustomRGB = 17,
		[InspectorName("Custom RGB+Intensity")]
		CustomIntensity = 18
	}
}
