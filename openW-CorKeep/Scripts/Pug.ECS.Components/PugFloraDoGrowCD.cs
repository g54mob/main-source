using Unity.Entities;
using Unity.Mathematics;

public struct PugFloraDoGrowCD : IComponentData, IQueryTypeParameter
{
	public bool initialize;

	public int2 position;
}
