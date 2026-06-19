using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EnemySpawnerPlatformCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity spawnedEntity;

	[GhostField]
	public bool isSpawning;

	public ThreadSafeTimerSimple timer;

	public ObjectID enemyToSpawn;

	public bool isCustomSceneSpawner => enemyToSpawn != ObjectID.None;
}
