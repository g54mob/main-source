using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
public struct GhostEffectEventBuffer : INetworkTickRingBuffer, IBufferElementData
{
	public const int CAPACITY = 3;

	[GhostField]
	public EffectEventCD value;

	[GhostField]
	public NetworkTick Tick { get; set; }
}
