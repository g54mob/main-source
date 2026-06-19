using Pug.UnityExtensions;
using Unity.Entities;

public struct DestroyEntityWhenNoNearbyPlayerCD : IComponentData, IQueryTypeParameter
{
	public float distanceSq;

	public ThreadSafeTimerSimple timer;

	public float destroyDelay;
}
