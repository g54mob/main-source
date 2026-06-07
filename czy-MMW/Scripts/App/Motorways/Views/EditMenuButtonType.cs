using System;

namespace Motorways.Views
{
	[Flags]
	public enum EditMenuButtonType
	{
		Flip = 1,
		Rotate = 2,
		UpgradeDowngrade = 4,
		Colour = 8,
		Confirm = 0x10,
		Decline = 0x20,
		Delete = 0x40,
		Move = 0x80
	}
}
