using Unity.Entities;
using Unity.Mathematics;

public struct SubMapCD : IComponentData, IQueryTypeParameter
{
	public int2 index;

	public bool wasCreatedThisSession;
}
