using Unity.Entities;

public struct SpawnDroppedItemCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectID;

	public int amount;

	public int repeats;

	public float timeBetweenSpawns;

	public float timer;
}
