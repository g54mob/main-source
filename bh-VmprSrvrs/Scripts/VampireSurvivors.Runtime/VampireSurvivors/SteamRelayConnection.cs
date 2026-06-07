using System;
using System.Collections.Generic;
using Coherence.Toolkit.Relay;
using Steamworks.Data;

namespace VampireSurvivors
{
	public class SteamRelayConnection : IRelayConnection
	{
		private Connection steamConnection;

		private readonly Queue<ArraySegment<byte>> messagesFromSteamToServer;

		public SteamRelayConnection(Connection steamConnection)
		{
		}

		public void OnConnectionOpened()
		{
		}

		public void OnConnectionClosed()
		{
		}

		public void EnqueueMessageFromSteam(ArraySegment<byte> packetData)
		{
		}

		public void ReceiveMessagesFromClient(List<ArraySegment<byte>> packetBuffer)
		{
		}

		public void SendMessageToClient(ReadOnlySpan<byte> packetData)
		{
		}
	}
}
