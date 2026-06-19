using Unity.Entities;

[InternalBufferCapacity(0)]
public struct AddPetExperienceBuffer : IBufferElementData
{
	public int amount;
}
