using Unity.Entities;

public struct EnableEntitiesTimerCD : IComponentData, IQueryTypeParameter
{
	public float RemainingTime;
}
