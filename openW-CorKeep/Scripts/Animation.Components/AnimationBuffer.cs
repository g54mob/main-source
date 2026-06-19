using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(1)]
public struct AnimationBuffer : INetworkTickRingBuffer, IBufferElementData
{
	public const int DEFAULT_CAPACITY = 1;

	public const int PLAYER_CAPACITY = 3;

	[GhostField]
	public int animID;

	[GhostField]
	public NetworkTick Tick { get; set; }
}
