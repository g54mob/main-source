using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
public struct LockedObjectsBuffer : IBufferElementData
{
	[GhostField]
	public bool Value;
}
