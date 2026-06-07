using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer.Events
{
	public class NetworkingMessagesSessionFailedEventArgs : EventArgs
	{
		public SteamNetworkingConnectionState State { get; }

		public ulong SteamId { get; }

		public NetworkingMessagesSessionFailedEventArgs(ulong steamId, SteamNetworkingConnectionState state)
		{
			SteamId = steamId;
			State = state;
		}
	}
}
