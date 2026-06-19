using Pug.UnityExtensions;
using Unity.Entities;

public struct SleepStateCD : IComponentData, IQueryTypeParameter
{
	public float minSleepCooldown;

	public float maxSleepCooldown;

	public float minPreFallAsleepDuration;

	public float maxPreFallAsleepDuration;

	public float minSleepDuration;

	public float maxSleepDuration;

	public float wakeUpDuration;

	public float radiusSqFromVisiblePlayerToAwake;

	public bool stayAwakeUntilNoVisiblePlayer;

	public float minSqRadiusFromOwnerToWakeUp;

	public float sleepCooldown;

	public int internalState;

	public ThreadSafeTimerSimple durationTimer;
}
