using System;

[Flags]
public enum PlatformFlags
{
	PC = 1,
	Switch = 2,
	Xbox = 4,
	Playstation = 8,
	PS4 = 0x10,
	PS5 = 0x20
}
