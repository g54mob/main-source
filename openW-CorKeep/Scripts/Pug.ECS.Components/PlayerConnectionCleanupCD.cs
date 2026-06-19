using Unity.Entities;

public struct PlayerConnectionCleanupCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
{
	public Entity playerEntity;
}
