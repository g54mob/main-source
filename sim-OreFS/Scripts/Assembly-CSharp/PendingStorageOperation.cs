using System;
using Mirror;

[Serializable]
public class PendingStorageOperation
{
	public enum OperationType
	{
		Add = 0,
		Remove = 1,
		AddItems = 2
	}

	public NetworkConnectionToClient requester;

	public OperationType operationType;

	public string itemId;

	public int count;

	public uint requesterNetId;

	public uint sackNetId;

	public PendingStorageOperation(NetworkConnectionToClient conn, OperationType opType, string id, int itemCount, uint netId)
	{
		requester = conn;
		operationType = opType;
		itemId = id;
		count = itemCount;
		requesterNetId = netId;
		sackNetId = 0u;
	}

	public PendingStorageOperation(NetworkConnectionToClient conn, OperationType opType, uint sackId, uint netId)
	{
		requester = conn;
		operationType = opType;
		itemId = string.Empty;
		count = 0;
		requesterNetId = netId;
		sackNetId = sackId;
	}
}
