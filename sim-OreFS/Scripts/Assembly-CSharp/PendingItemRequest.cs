using System;
using Mirror;

[Serializable]
public class PendingItemRequest
{
	public NetworkConnectionToClient requester;

	public uint requesterNetId;

	public PendingItemRequest(NetworkConnectionToClient conn, uint netId)
	{
		requester = conn;
		requesterNetId = netId;
	}
}
