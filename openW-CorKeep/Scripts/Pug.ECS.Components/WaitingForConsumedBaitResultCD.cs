using Unity.Entities;

public struct WaitingForConsumedBaitResultCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public int resultIndex;

	public bool isFishingAtOctopusBoss;

	public Entity octopusBossEntity;

	public Entity octopusBossSpawnLocationEntity;

	public bool spawnOctopusBoss;

	public Entity fishShoalEntity;

	public bool fishOnTheHook;

	public ObjectID fishingLootToSpawn;
}
