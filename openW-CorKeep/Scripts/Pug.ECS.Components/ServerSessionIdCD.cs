using Unity.Entities;

public struct ServerSessionIdCD : IComponentData, IQueryTypeParameter
{
	public Hash128 Value;
}
