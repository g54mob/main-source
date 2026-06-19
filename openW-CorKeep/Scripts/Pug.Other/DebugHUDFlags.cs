using System;

[Flags]
public enum DebugHUDFlags
{
	fps = 1,
	heap = 2,
	pools = 4,
	rawInput = 8,
	tvSafeAreaOverlay = 0x10,
	screenSize = 0x20
}
