using System;

[Flags]
public enum MapEntityStates
{
	None = 0,
	Destroyed = 1,
	Damaged = 2,
	Moving = 0x40,
	Hidden = 0x80
}
