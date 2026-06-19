using Unity.Entities;

public struct GhostWaitingSpawnInitCD : IComponentData, IQueryTypeParameter
{
	public Entity mainEntity;
}
