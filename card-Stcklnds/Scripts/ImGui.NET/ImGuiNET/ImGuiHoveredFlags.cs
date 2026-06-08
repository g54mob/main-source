using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiHoveredFlags
	{
		None = 0,
		ChildWindows = 1,
		RootWindow = 2,
		AnyWindow = 4,
		NoPopupHierarchy = 8,
		DockHierarchy = 0x10,
		AllowWhenBlockedByPopup = 0x20,
		AllowWhenBlockedByActiveItem = 0x80,
		AllowWhenOverlapped = 0x100,
		AllowWhenDisabled = 0x200,
		NoNavOverride = 0x400,
		RectOnly = 0x1A0,
		RootAndChildWindows = 3,
		DelayNormal = 0x800,
		DelayShort = 0x1000,
		NoSharedDelay = 0x2000
	}
}
