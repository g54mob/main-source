using Unity.Entities;

[InternalBufferCapacity(0)]
public struct IsAffectedByAurasFromEntitiesBuffer : IBufferElementData, IEnableableComponent
{
	public Entity affectedByAuraFromEntity;
}
