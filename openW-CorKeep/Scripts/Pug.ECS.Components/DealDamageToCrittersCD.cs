using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct DealDamageToCrittersCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool squashBugs;

	[GhostField]
	public float2 lastDamagePos;
}
