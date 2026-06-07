using System;

[Flags]
public enum ovrAvatarCapabilities
{
	Body = 1,
	Hands = 2,
	Base = 4,
	BodyTilt = 0x10,
	Expressive = 0x20,
	All = -1
}
