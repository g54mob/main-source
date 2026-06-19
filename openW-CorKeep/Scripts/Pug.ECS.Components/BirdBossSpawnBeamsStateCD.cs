using Pug.UnityExtensions;
using Unity.Entities;

public struct BirdBossSpawnBeamsStateCD : IComponentData, IQueryTypeParameter
{
	public float durationUntilBeamSpawn;

	public float durationAfterBeamSpawn;

	public float minCooldown;

	public float maxCooldown;

	public ThreadSafeTimerSimple cooldownTimer;

	public int internalState;

	public ThreadSafeTimerSimple timer;
}
