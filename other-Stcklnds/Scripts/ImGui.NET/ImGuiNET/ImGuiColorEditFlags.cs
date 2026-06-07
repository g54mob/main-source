using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiColorEditFlags
	{
		None = 0,
		NoAlpha = 2,
		NoPicker = 4,
		NoOptions = 8,
		NoSmallPreview = 0x10,
		NoInputs = 0x20,
		NoTooltip = 0x40,
		NoLabel = 0x80,
		NoSidePreview = 0x100,
		NoDragDrop = 0x200,
		NoBorder = 0x400,
		AlphaBar = 0x10000,
		AlphaPreview = 0x20000,
		AlphaPreviewHalf = 0x40000,
		HDR = 0x80000,
		DisplayRGB = 0x100000,
		DisplayHSV = 0x200000,
		DisplayHex = 0x400000,
		Uint8 = 0x800000,
		Float = 0x1000000,
		PickerHueBar = 0x2000000,
		PickerHueWheel = 0x4000000,
		InputRGB = 0x8000000,
		InputHSV = 0x10000000,
		DefaultOptions = 0xA900000,
		DisplayMask = 0x700000,
		DataTypeMask = 0x1800000,
		PickerMask = 0x6000000,
		InputMask = 0x18000000
	}
}
