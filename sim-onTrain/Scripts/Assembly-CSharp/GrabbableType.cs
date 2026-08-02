using System;

[Flags]
public enum GrabbableType
{
	None = 0,
	Wall = 1,
	Ground = 2,
	Roof = 4,
	Pillor = 8,
	Prop = 0x10,
	CenterWall = 0x20,
	WallProp = 0x40,
	Pipe = 0x80
}
