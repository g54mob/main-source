using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(12)]
public struct SkillBuffer : IBufferElementData
{
	[GhostField]
	public int Value;
}
