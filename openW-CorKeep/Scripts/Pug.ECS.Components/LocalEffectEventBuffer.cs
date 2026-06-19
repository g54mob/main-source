using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct LocalEffectEventBuffer : INetworkTickRingBuffer, IBufferElementData
{
	public const int CAPACITY = 10;

	public EffectEventCD value;

	public NetworkTick Tick { get; set; }
}
