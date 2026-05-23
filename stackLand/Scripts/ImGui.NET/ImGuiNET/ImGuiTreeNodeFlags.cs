using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiTreeNodeFlags
	{
		None = 0,
		Selected = 1,
		Framed = 2,
		AllowItemOverlap = 4,
		NoTreePushOnOpen = 8,
		NoAutoOpenOnLog = 0x10,
		DefaultOpen = 0x20,
		OpenOnDoubleClick = 0x40,
		OpenOnArrow = 0x80,
		Leaf = 0x100,
		Bullet = 0x200,
		FramePadding = 0x400,
		SpanAvailWidth = 0x800,
		SpanFullWidth = 0x1000,
		NavLeftJumpsBackHere = 0x2000,
		CollapsingHeader = 0x1A
	}
}
