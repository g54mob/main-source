using Unity.Entities;

public struct PugDamagePrefabsCD : IComponentData, IQueryTypeParameter
{
	public Entity DamageTakenPrefab;
}
