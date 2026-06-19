using System;

[Flags]
public enum DyingMessageSessionFlags
{
	None = 0,
	IsOnline = 1,
	IsHost = 2,
	IsInGame = 4,
	SwitchDocked = 8
}
