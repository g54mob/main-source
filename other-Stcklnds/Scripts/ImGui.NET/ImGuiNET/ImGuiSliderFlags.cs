using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiSliderFlags
	{
		None = 0,
		AlwaysClamp = 0x10,
		Logarithmic = 0x20,
		NoRoundToFormat = 0x40,
		NoInput = 0x80,
		InvalidMask = 0x7000000F
	}
}
