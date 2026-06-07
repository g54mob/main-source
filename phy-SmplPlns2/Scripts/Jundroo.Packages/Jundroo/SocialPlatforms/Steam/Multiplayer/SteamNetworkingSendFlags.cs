using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer
{
	[Flags]
	public enum SteamNetworkingSendFlags
	{
		Unreliable = 0,
		NoNagle = 1,
		UnreliableNoNagle = 1,
		NoDelay = 4,
		UnreliableNoDelay = 5,
		Send_Reliable = 8,
		ReliableNoNagle = 9
	}
}
