using System;

namespace Aggro.Core
{
	[Flags]
	public enum InputRebindKbmMask
	{
		None = 0,
		MouseButtons = 1,
		MouseScroll = 2,
		KeyboardKeys = 4,
		ReadOnly = 0x100
	}
}
