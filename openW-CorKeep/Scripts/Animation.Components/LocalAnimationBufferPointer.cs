using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct LocalAnimationBufferPointer : INetworkTickRingBufferPointer, IComponentData, IQueryTypeParameter
{
	public byte NextIndex { get; set; }
}
