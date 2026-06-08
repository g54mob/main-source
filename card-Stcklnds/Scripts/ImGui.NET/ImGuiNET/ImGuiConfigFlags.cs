using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiConfigFlags
	{
		None = 0,
		NavEnableKeyboard = 1,
		NavEnableGamepad = 2,
		NavEnableSetMousePos = 4,
		NavNoCaptureKeyboard = 8,
		NoMouse = 0x10,
		NoMouseCursorChange = 0x20,
		DockingEnable = 0x40,
		ViewportsEnable = 0x400,
		DpiEnableScaleViewports = 0x4000,
		DpiEnableScaleFonts = 0x8000,
		IsSRGB = 0x100000,
		IsTouchScreen = 0x200000
	}
}
