using Unity.Entities;
using Unity.NetCode;

public struct PlayerRecentAttackersBufferPointerCD : INetworkTickRingBufferPointer, IComponentData, IQueryTypeParameter
{
	[GhostField]
	public byte NextIndex { get; set; }
}
