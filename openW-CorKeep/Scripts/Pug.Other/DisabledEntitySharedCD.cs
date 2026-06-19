using Unity.Entities;
using Unity.Mathematics;

public struct DisabledEntitySharedCD : ISharedComponentData, IQueryTypeParameter
{
	public int2 position;
}
