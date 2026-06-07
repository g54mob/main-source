using System;
using System.Collections.Generic;

namespace Coherence.Toolkit.Relay
{
	public interface IRelayConnection
	{
		void OnConnectionOpened();

		void OnConnectionClosed();

		void ReceiveMessagesFromClient(List<ArraySegment<byte>> packetBuffer);

		void SendMessageToClient(ReadOnlySpan<byte> packetData);
	}
}
