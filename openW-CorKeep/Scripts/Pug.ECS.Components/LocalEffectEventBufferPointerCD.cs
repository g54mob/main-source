using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct LocalEffectEventBufferPointerCD : INetworkTickRingBufferPointer, IComponentData, IQueryTypeParameter
{
	public byte NextIndex { get; set; }
}
