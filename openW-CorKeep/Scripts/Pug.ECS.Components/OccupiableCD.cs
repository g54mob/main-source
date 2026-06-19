using Unity.Entities;
using Unity.Mathematics;

public struct OccupiableCD : IComponentData, IQueryTypeParameter
{
	public float3 occupyOffsetForward;

	public float3 occupyOffsetRight;

	public float3 occupyOffsetBack;

	public float3 occupyOffsetLeft;
}
