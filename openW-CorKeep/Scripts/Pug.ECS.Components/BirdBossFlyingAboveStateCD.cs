using Pug.UnityExtensions;
using Unity.Entities;

public struct BirdBossFlyingAboveStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple flyAnimCooldownTimer;

	public ThreadSafeTimerSimple timer;

	public int internalState;

	public bool hasEnteredStateOnce;
}
