using Unity.Entities;

[InternalBufferCapacity(1)]
public struct NewCombatantsBuffer : IBufferElementData
{
	public Entity Target;
}
