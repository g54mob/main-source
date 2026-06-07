using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiTabItemFlags
	{
		None = 0,
		UnsavedDocument = 1,
		SetSelected = 2,
		NoCloseWithMiddleMouseButton = 4,
		NoPushId = 8,
		NoTooltip = 0x10,
		NoReorder = 0x20,
		Leading = 0x40,
		Trailing = 0x80
	}
}
