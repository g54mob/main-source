using Unity.Entities;

public struct IgnitableCD : IComponentData, IQueryTypeParameter
{
	public ObjectID spawnOnIgnitedObjectID;

	public int spawnOnIgnitedVariation;
}
