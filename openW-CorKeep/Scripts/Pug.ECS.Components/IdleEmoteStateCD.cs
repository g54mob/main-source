using Pug.UnityExtensions;
using Unity.Entities;

public struct IdleEmoteStateCD : IComponentData, IQueryTypeParameter
{
	public int animationIndexToPlay;

	public ThreadSafeTimerSimple durationTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public int internalState;
}
