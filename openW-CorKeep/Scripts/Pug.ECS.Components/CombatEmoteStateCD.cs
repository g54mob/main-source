using Pug.UnityExtensions;
using Unity.Entities;

public struct CombatEmoteStateCD : IComponentData, IQueryTypeParameter
{
	public enum InternalState
	{
		Init = 0,
		PreEmoteIdle = 1,
		PlayingEmote = 2
	}

	public int animationIndexToPlay;

	public Entity optionalTarget;

	public ThreadSafeTimerSimple durationTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public InternalState internalState;
}
