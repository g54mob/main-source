using Unity.Entities;

public struct InitializeClaimedBedCD : IComponentData, IQueryTypeParameter
{
	public Entity entity;
}
