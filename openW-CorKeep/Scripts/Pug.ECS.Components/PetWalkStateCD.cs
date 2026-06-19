using Pug.UnityExtensions;
using Unity.Entities;

public struct PetWalkStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple pathFindTimer;

	public ThreadSafeTimerSimple attemptToAttackCooldownTimer;

	public float lastDistanceToOwner;

	public float currentSpeedMultiplier;

	public int internalState;

	public Entity pathFindEntity;
}
