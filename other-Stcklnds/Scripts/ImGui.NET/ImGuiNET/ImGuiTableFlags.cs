using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiTableFlags
	{
		None = 0,
		Resizable = 1,
		Reorderable = 2,
		Hideable = 4,
		Sortable = 8,
		NoSavedSettings = 0x10,
		ContextMenuInBody = 0x20,
		RowBg = 0x40,
		BordersInnerH = 0x80,
		BordersOuterH = 0x100,
		BordersInnerV = 0x200,
		BordersOuterV = 0x400,
		BordersH = 0x180,
		BordersV = 0x600,
		BordersInner = 0x280,
		BordersOuter = 0x500,
		Borders = 0x780,
		NoBordersInBody = 0x800,
		NoBordersInBodyUntilResize = 0x1000,
		SizingFixedFit = 0x2000,
		SizingFixedSame = 0x4000,
		SizingStretchProp = 0x6000,
		SizingStretchSame = 0x8000,
		NoHostExtendX = 0x10000,
		NoHostExtendY = 0x20000,
		NoKeepColumnsVisible = 0x40000,
		PreciseWidths = 0x80000,
		NoClip = 0x100000,
		PadOuterX = 0x200000,
		NoPadOuterX = 0x400000,
		NoPadInnerX = 0x800000,
		ScrollX = 0x1000000,
		ScrollY = 0x2000000,
		SortMulti = 0x4000000,
		SortTristate = 0x8000000,
		SizingMask = 0xE000
	}
}
