using Unity.Entities;
using Unity.NetCode;

public struct SetVariationRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public Entity entity;

	public int variation;

	public int updateCount;
}
