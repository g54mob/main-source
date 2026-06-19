using Unity.Entities;
using Unity.NetCode;

public struct AnimationBufferPointer : INetworkTickRingBufferPointer, IComponentData, IQueryTypeParameter
{
	[GhostField]
	public byte NextIndex { get; set; }
}
