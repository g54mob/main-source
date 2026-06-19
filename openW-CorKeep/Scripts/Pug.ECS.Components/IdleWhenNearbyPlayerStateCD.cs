using Pug.UnityExtensions;
using Unity.Entities;

public struct IdleWhenNearbyPlayerStateCD : IComponentData, IQueryTypeParameter
{
	public float sqDistanceToStartIdle;

	public int internalState;

	public Entity currentNearPlayer;

	public ThreadSafeTimerSimple lookAtPlayerTimer;
}
