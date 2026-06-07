using System;

namespace Noesis
{
	[Flags]
	public enum DragDropKeyStates
	{
		None = 0,
		LeftMouseButton = 1,
		RightMouseButton = 2,
		ShiftKey = 4,
		ControlKey = 8,
		MiddleMouseButton = 0x10,
		AltKey = 0x20
	}
}
