using System;

namespace Jundroo.SocialPlatforms.Steam.Multiplayer
{
	public struct SteamNetworkingMessage
	{
		public ArraySegment<byte> Data { get; }

		public ulong SenderSteamId { get; }

		public SteamNetworkingMessage(ulong senderSteamId, ArraySegment<byte> data)
		{
			SenderSteamId = senderSteamId;
			Data = data;
		}
	}
}
