using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CoreBossSpawnCD : IComponentData, IQueryTypeParameter
{
	public float distanceSqToPlayerToActivate;

	public float distanceSqToPlayerToSpawn;

	public float spawnTime;

	public float destructionTime;

	public ThreadSafeTimerSimple timer;

	public float spawnZOffset;

	public bool triggerSpawn;

	public float introTimeDuration;

	[GhostField]
	public CoreBossSpawnState state;
}
