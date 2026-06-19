using Unity.Entities;

public struct BaitableCD : IComponentData, IQueryTypeParameter
{
	public Entity baitEntity;
}
