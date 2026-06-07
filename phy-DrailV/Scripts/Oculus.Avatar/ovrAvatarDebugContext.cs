using System;

[Flags]
public enum ovrAvatarDebugContext : uint
{
	None = 0u,
	GazeTarget = 1u,
	Any = uint.MaxValue
}
