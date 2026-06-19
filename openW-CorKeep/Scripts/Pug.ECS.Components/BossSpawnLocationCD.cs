using Unity.Entities;

public struct BossSpawnLocationCD : IComponentData, IQueryTypeParameter
{
	public ObjectID bossID;
}
