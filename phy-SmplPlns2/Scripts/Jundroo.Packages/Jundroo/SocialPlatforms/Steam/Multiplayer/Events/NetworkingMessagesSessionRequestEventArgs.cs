using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class NetworkingMessagesSessionRequestEventArgs : EventArgs
	{
		public ulong SteamId { get; }

		public NetworkingMessagesSessionRequestEventArgs(ulong steamId)
		{
			SteamId = steamId;
		}
	}
}
