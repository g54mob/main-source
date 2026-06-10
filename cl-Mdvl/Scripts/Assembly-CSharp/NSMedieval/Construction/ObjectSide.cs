using System;

namespace NSMedieval.Construction
{
	[Flags]
	public enum ObjectSide
	{
		Bottom = 1,
		Top = 2,
		Left = 4,
		Right = 8,
		Front = 0x10,
		Back = 0x20,
		None = 0x40
	}
}
