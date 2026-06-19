using Unity.Entities;

public struct OnlyRelevantForConnectionCD : IComponentData, IQueryTypeParameter
{
	public int networkId;
}
