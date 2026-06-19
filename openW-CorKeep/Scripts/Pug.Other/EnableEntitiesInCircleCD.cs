using Unity.Entities;
using Unity.Mathematics;

public struct EnableEntitiesInCircleCD : IComponentData, IQueryTypeParameter
{
	public float2 Center;

	public float Radius;
}
