using Mirror;

public struct WebSocketRelayMessage : NetworkMessage
{
	public string rawData;

	public string messageType;
}
