using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImDrawFlags
	{
		None = 0,
		Closed = 1,
		RoundCornersTopLeft = 0x10,
		RoundCornersTopRight = 0x20,
		RoundCornersBottomLeft = 0x40,
		RoundCornersBottomRight = 0x80,
		RoundCornersNone = 0x100,
		RoundCornersTop = 0x30,
		RoundCornersBottom = 0xC0,
		RoundCornersLeft = 0x50,
		RoundCornersRight = 0xA0,
		RoundCornersAll = 0xF0,
		RoundCornersDefault = 0xF0,
		RoundCornersMask = 0x1F0
	}
}
