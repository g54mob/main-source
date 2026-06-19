using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(3)]
[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct LocalAnimationBuffer : INetworkTickRingBuffer, IBufferElementData
{
	public const int DEFAULT_CAPACITY = 3;

	public const int PLAYER_CAPACITY = 6;

	public int animID;

	public NetworkTick Tick { get; set; }
}
