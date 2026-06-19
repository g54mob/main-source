using Unity.Entities;

public struct FullnessCD : IComponentData, IQueryTypeParameter
{
	public int maxFullness;
}
