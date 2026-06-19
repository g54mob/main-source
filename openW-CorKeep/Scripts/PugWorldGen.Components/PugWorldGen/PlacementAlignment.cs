using System;

namespace PugWorldGen
{
	[Flags]
	public enum PlacementAlignment
	{
		Anywhere = 0,
		Forward = 1,
		Back = 2,
		Left = 4,
		Right = 8,
		ForwardLeft = 0x10,
		ForwardRight = 0x20,
		BackLeft = 0x40,
		BackRight = 0x80,
		Inside = 0x100
	}
}
