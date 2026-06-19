using Unity.Entities;

public struct PlayerLastSessionCD : IComponentData, IQueryTypeParameter
{
	public Hash128 Value;
}
