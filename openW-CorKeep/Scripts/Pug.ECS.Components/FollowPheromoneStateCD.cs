using Pug.UnityExtensions;
using Unity.Entities;

public struct FollowPheromoneStateCD : IComponentData, IQueryTypeParameter
{
	public PheromoneMask mask;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple keepFollowingTimer;
}
