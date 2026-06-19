using Unity.Entities;
using Unity.NetCode;

public interface INetworkTickRingBuffer : IBufferElementData
{
	NetworkTick Tick { get; set; }
}
