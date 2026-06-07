using System;
using System.Collections.Generic;
using Coherence.Toolkit.Relay;
using PlayFab.Party;

public class PlayFabRelayConnection : IRelayConnection
{
	private IEnumerable<PlayFabPlayer> player;

	private PlayFabMultiplayerManager manager;

	private readonly Queue<ArraySegment<byte>> messagesFromPlayFabToServer;

	public PlayFabRelayConnection(PlayFabPlayer player, PlayFabMultiplayerManager manager)
	{
	}

	public void OnConnectionOpened()
	{
	}

	public void OnConnectionClosed()
	{
	}

	public void ReceiveMessagesFromClient(List<ArraySegment<byte>> packetBuffer)
	{
	}

	public void SendMessageToClient(ReadOnlySpan<byte> packetData)
	{
	}

	public void EnqueueMessageFromPlayFab(ArraySegment<byte> packet)
	{
	}
}
