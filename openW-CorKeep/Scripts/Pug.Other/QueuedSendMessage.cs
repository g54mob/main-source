using Unity.Networking.Transport;

public struct QueuedSendMessage
{
	public unsafe fixed byte Data[1200];

	public NetworkEndpoint Source;

	public NetworkEndpoint Dest;

	public int DataLength;
}
