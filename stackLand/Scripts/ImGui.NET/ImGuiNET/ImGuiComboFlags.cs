using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiComboFlags
	{
		None = 0,
		PopupAlignLeft = 1,
		HeightSmall = 2,
		HeightRegular = 4,
		HeightLarge = 8,
		HeightLargest = 0x10,
		NoArrowButton = 0x20,
		NoPreview = 0x40,
		HeightMask = 0x1E
	}
}
