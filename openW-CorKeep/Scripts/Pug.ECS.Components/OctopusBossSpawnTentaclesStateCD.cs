using Pug.UnityExtensions;
using Unity.Entities;

public struct OctopusBossSpawnTentaclesStateCD : IComponentData, IQueryTypeParameter
{
	public float durationBeforeStartingToSpawn;

	public float durationUntilSpawn;

	public float durationAfterSpawn;

	public float durationBeforeLeaveSpawnState;

	public float minCooldown;

	public float maxCooldown;

	public ThreadSafeTimerSimple cooldownTimer;

	public int internalState;

	public ThreadSafeTimerSimple timer;
}
