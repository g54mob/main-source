using Unity.Entities;
using Unity.NetCode;

public struct OilCombustByConditionsCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool hadOilAndBurning;
}
