using Pug.UnityExtensions;
using Unity.Entities;

public struct ChaseStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple phaseChaseTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple chaseTimer;

	public ThreadSafeTimerSimple idleCooldownTimer;

	public ThreadSafeTimerSimple idleTimer;

	public ThreadSafeTimerSimple breedCheckCooldownTimer;

	public ThreadSafeTimerSimple restartBreedCheckCooldownTimer;

	public ThreadSafeTimerSimple lastAttackerCheckCooldownTimer;

	public Entity targetEntity;

	public Entity pathFindEntity;

	public int internalState;

	public float chaseAtDistanceSq;

	public float shouldEnterStateCheckTimer;

	public bool distanceToKeepNoiseDisabled;

	public bool isDisabled;

	public bool neverTimeoutChasing;

	public bool invertSideStepDirection;

	public bool hadTargetInSight;

	public bool isChasingByLastAttacker;

	public bool isMinionCommandTarget;
}
