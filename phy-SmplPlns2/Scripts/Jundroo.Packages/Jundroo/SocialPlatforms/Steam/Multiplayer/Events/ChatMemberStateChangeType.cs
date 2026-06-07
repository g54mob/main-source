using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	[Flags]
	public enum ChatMemberStateChangeType
	{
		Entered = 1,
		Left = 2,
		Disconnected = 4,
		Kicked = 8,
		Banned = 0x10
	}
}
