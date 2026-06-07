using System;

namespace Motorways.Audio
{
	[Flags]
	public enum UIEventType
	{
		None = 0,
		MouseOver = 1,
		MouseOut = 2,
		MouseDown = 4,
		MouseUp = 8,
		Click = 0x10,
		CheckboxChecked = 0x20,
		CheckboxUnchecked = 0x40,
		Transition = 0x80,
		FocusZoomIn = 0x100,
		FocusZoomOut = 0x200
	}
}
