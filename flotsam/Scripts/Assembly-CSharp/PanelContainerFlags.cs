using System;

[Flags]
public enum PanelContainerFlags
{
	None = 0,
	BlockCursorContext = 1,
	BlockCameraInput = 2,
	BlockDPadInput = 4,
	BlockDrifterOverview = 8,
	BlockNotificationHandler = 0x10,
	RestrictUINavigation = 0x20,
	BlockGameSpeed = 0x40,
	ExemptGameSpeed = 0x10000
}
