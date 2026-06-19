using Unity.Entities;

[InternalBufferCapacity(0)]
public struct AlwaysActiveConnectionsBuffer : IBufferElementData
{
	public ConnectionAndDirection connection;
}
