using Unity.Entities;
using Unity.NetCode;

public struct NetworkCommMessageRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public int messageNumber;

	public NetworkCommMessageType messageType;

	public int totalSize;

	public byte platform;

	public ulong platformID;

	public bool isStreamIntegrationMessage;
}
