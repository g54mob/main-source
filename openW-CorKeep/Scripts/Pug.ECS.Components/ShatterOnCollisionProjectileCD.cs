using Unity.Entities;

public struct ShatterOnCollisionProjectileCD : IComponentData, IQueryTypeParameter
{
	public int shards;

	public ObjectID shardObjectID;
}
