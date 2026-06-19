using Pug.UnityExtensions;
using Unity.Entities;

public struct AlertEmoteStateCD : IComponentData, IQueryTypeParameter
{
	public int animations;

	public float preAlertMinDuration;

	public float preAlertMaxDuration;

	public float duration;

	public float minCooldown;

	public float maxCooldown;

	public ThreadSafeTimerSimple durationTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public int internalState;
}
