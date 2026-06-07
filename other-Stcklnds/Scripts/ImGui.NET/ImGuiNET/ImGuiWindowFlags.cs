using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiWindowFlags
	{
		None = 0,
		NoTitleBar = 1,
		NoResize = 2,
		NoMove = 4,
		NoScrollbar = 8,
		NoScrollWithMouse = 0x10,
		NoCollapse = 0x20,
		AlwaysAutoResize = 0x40,
		NoBackground = 0x80,
		NoSavedSettings = 0x100,
		NoMouseInputs = 0x200,
		MenuBar = 0x400,
		HorizontalScrollbar = 0x800,
		NoFocusOnAppearing = 0x1000,
		NoBringToFrontOnFocus = 0x2000,
		AlwaysVerticalScrollbar = 0x4000,
		AlwaysHorizontalScrollbar = 0x8000,
		AlwaysUseWindowPadding = 0x10000,
		NoNavInputs = 0x40000,
		NoNavFocus = 0x80000,
		UnsavedDocument = 0x100000,
		NoDocking = 0x200000,
		NoNav = 0xC0000,
		NoDecoration = 0x2B,
		NoInputs = 0xC0200,
		NavFlattened = 0x800000,
		ChildWindow = 0x1000000,
		Tooltip = 0x2000000,
		Popup = 0x4000000,
		Modal = 0x8000000,
		ChildMenu = 0x10000000,
		DockNodeHost = 0x20000000
	}
}
