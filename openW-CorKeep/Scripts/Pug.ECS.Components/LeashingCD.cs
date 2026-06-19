using Unity.Entities;
using Unity.NetCode;

public struct LeashingCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity leashedEntity;
}
