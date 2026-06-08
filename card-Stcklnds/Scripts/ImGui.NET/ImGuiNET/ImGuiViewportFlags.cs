using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiViewportFlags
	{
		None = 0,
		IsPlatformWindow = 1,
		IsPlatformMonitor = 2,
		OwnedByApp = 4,
		NoDecoration = 8,
		NoTaskBarIcon = 0x10,
		NoFocusOnAppearing = 0x20,
		NoFocusOnClick = 0x40,
		NoInputs = 0x80,
		NoRendererClear = 0x100,
		TopMost = 0x200,
		Minimized = 0x400,
		NoAutoMerge = 0x800,
		CanHostOtherWindows = 0x1000
	}
}
