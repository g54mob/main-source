using Pug.UnityExtensions;
using Unity.Entities;

public struct CoreBossSpawnVoidStateCD : IComponentData, IQueryTypeParameter
{
	public bool isDisabled;

	public CoreBossSpawnVoidInternalState internalState;

	public ThreadSafeTimerSimple cooldownTimer;

	public float minCooldown;

	public float maxCooldown;

	public ThreadSafeTimerSimple timer;

	public float durationUntilSpawn;

	public float durationAfterSpawn;

	public float duration;

	public VoidZoneType voidZoneType;
}
