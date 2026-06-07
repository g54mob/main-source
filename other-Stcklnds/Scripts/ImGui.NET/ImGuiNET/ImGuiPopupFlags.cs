using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiPopupFlags
	{
		None = 0,
		MouseButtonLeft = 0,
		MouseButtonRight = 1,
		MouseButtonMiddle = 2,
		MouseButtonMask = 0x1F,
		MouseButtonDefault = 1,
		NoOpenOverExistingPopup = 0x20,
		NoOpenOverItems = 0x40,
		AnyPopupId = 0x80,
		AnyPopupLevel = 0x100,
		AnyPopup = 0x180
	}
}
