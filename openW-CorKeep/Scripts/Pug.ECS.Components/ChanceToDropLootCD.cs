using Unity.Entities;

public struct ChanceToDropLootCD : IComponentData, IQueryTypeParameter
{
	public float chance;
}
