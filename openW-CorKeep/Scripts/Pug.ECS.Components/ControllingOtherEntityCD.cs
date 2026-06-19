using Unity.Entities;
using Unity.NetCode;

public struct ControllingOtherEntityCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity requestToBeControlledEntity;

	[GhostField]
	public Entity controlledEntity;
}
