using System;

[Flags]
public enum ETextureSurfaceType
{
	Constructable = 1,
	Navigation = 2,
	EndPlusX = 4,
	EndMinusX = 8,
	EndPlusY = 0x10,
	EndMinusY = 0x20,
	End = 0x3C
}
