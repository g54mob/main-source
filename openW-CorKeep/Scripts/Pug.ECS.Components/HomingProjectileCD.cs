using Unity.Entities;

public struct HomingProjectileCD : IComponentData, IQueryTypeParameter
{
	public Entity followingEntity;
}
