using System;
using Unity.Entities;
using Unity.NetCode;

[Serializable]
[GhostComponent(PrefabType = GhostPrefabType.All)]
[InternalBufferCapacity(0)]
public struct DescriptionBuffer : IBufferElementData
{
	[GhostField]
	public byte Value;
}
