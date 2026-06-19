using Pug.UnityExtensions;
using Unity.Entities;

public struct ScarabBossBuriedStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple timer;

	public int internalState;

	public bool hasEnteredStateOnce;
}
