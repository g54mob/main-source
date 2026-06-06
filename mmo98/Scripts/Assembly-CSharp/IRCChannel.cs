using System;

[Flags]
public enum IRCChannel
{
	None = 0,
	Default = 1,
	Gnorman = 2,
	System = 4,
	Twitch = 8,
	All = 0xF
}
