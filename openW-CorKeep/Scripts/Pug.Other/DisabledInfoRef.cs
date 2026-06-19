using Unity.Entities;

public struct DisabledInfoRef : IComponentData, IQueryTypeParameter
{
	public int Index;
}
