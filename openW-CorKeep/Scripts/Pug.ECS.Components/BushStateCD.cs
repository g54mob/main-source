using Pug.UnityExtensions;
using Unity.Entities;

public struct BushStateCD : IComponentData, IQueryTypeParameter
{
	public enum InternalState
	{
		EnterState = 0,
		InBush = 1,
		Peek = 2,
		LeaveBush = 3,
		ExitState = 4
	}

	public InternalState nextInternalStateOnTimerElapse;

	public float distanceToTargetToLeaveStateSq;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple randomlyLeaveStatetimer;

	public ThreadSafeTimerSimple cooldownTimer;
}
