using Unity.Entities;

public struct WarmupCD : IComponentData, IQueryTypeParameter
{
	public float warmupTime;
}
