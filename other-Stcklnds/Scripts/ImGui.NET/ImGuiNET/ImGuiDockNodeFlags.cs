using System;

namespace ImGuiNET
{
	[Flags]
	public enum ImGuiDockNodeFlags
	{
		None = 0,
		KeepAliveOnly = 1,
		NoDockingInCentralNode = 4,
		PassthruCentralNode = 8,
		NoSplit = 0x10,
		NoResize = 0x20,
		AutoHideTabBar = 0x40
	}
}
