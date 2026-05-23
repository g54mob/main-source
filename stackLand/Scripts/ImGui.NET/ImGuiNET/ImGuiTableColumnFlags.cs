using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiTableColumnFlags
	{
		None = 0,
		Disabled = 1,
		DefaultHide = 2,
		DefaultSort = 4,
		WidthStretch = 8,
		WidthFixed = 0x10,
		NoResize = 0x20,
		NoReorder = 0x40,
		NoHide = 0x80,
		NoClip = 0x100,
		NoSort = 0x200,
		NoSortAscending = 0x400,
		NoSortDescending = 0x800,
		NoHeaderLabel = 0x1000,
		NoHeaderWidth = 0x2000,
		PreferSortAscending = 0x4000,
		PreferSortDescending = 0x8000,
		IndentEnable = 0x10000,
		IndentDisable = 0x20000,
		IsEnabled = 0x1000000,
		IsVisible = 0x2000000,
		IsSorted = 0x4000000,
		IsHovered = 0x8000000,
		WidthMask = 0x18,
		IndentMask = 0x30000,
		StatusMask = 0xF000000,
		NoDirectResize = 0x40000000
	}
}
