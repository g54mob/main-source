using Pug.UnityExtensions;
using Unity.Entities;

public struct BossLarvaSpawnerCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple bossLarvaSpawnTimer;

	public bool hasSpawnedInitialBossLarva;
}
