using Unity.Entities;

public struct DestroyNearbyEntitiesOnDeathCD : IComponentData, IQueryTypeParameter
{
	public float radius;

	public bool killAnyTemporaryEnemy;

	public bool destroyEntitiesWithDontDestroyOnZeroHealthCD;
}
