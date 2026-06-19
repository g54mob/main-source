using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
public struct PlayerRecentAttackersBuffer : INetworkTickRingBuffer, IBufferElementData
{
	public const int DEFAULT_CAPACITY = 8;

	[GhostField]
	public Entity attacker;

	[GhostField]
	public NetworkTick Tick { get; set; }
}
