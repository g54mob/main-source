using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiTabBarFlags
	{
		None = 0,
		Reorderable = 1,
		AutoSelectNewTabs = 2,
		TabListPopupButton = 4,
		NoCloseWithMiddleMouseButton = 8,
		NoTabListScrollingButtons = 0x10,
		NoTooltip = 0x20,
		FittingPolicyResizeDown = 0x40,
		FittingPolicyScroll = 0x80,
		FittingPolicyMask = 0xC0,
		FittingPolicyDefault = 0x40
	}
}
