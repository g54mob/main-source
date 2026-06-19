using Unity.Entities;

public struct ConsumesManaCD : IComponentData, IQueryTypeParameter
{
	public int manaCost;
}
