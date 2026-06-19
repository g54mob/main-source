using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;

public struct RoamingStateCD : IComponentData, IQueryTypeParameter
{
	public enum RoamingInternalState
	{
		Idle = 0,
		BeginMoving = 1,
		Moving = 2
	}

	public bool isDisabled;

	public float tileDamageRadius;

	public float distanceInfrontToDamageTiles;

	public int currentPathIndex;

	public RoamingInternalState internalState;

	public bool directionReversed;

	public ThreadSafeTimerSimple reverseDirectionTimer;

	public ThreadSafeTimerSimple reverseDirectionCooldownTimer;

	public FixedList32Bytes<ObjectID> cantHitSpecificObjects;
}
