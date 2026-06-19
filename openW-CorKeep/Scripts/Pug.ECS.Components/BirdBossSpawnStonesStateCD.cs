using Pug.UnityExtensions;
using Unity.Entities;

public struct BirdBossSpawnStonesStateCD : IComponentData, IQueryTypeParameter
{
	public float durationBeforeStartingToSpawnStones;

	public float durationUntilStonesSpawn;

	public float durationAfterStonesSpawn;

	public float durationBeforeLeaveStonesSpawnState;

	public float minCooldown;

	public float maxCooldown;

	public ThreadSafeTimerSimple cooldownTimer;

	public int internalState;

	public ThreadSafeTimerSimple timer;
}
