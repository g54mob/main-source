using System;

[Flags]
public enum GameEventPlatform : byte
{
	None = 0,
	Steam = 1,
	XboxOne = 2,
	Switch = 4
}
