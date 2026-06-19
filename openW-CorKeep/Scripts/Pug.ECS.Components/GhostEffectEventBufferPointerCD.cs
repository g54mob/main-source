using Unity.Entities;
using Unity.NetCode;

public struct GhostEffectEventBufferPointerCD : INetworkTickRingBufferPointer, IComponentData, IQueryTypeParameter
{
	[GhostField]
	public byte NextIndex { get; set; }
}
