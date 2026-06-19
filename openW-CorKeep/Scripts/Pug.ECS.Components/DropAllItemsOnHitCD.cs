using Unity.Entities;
using Unity.Mathematics;

public struct DropAllItemsOnHitCD : IComponentData, IQueryTypeParameter
{
	public float3 dropOffset;
}
