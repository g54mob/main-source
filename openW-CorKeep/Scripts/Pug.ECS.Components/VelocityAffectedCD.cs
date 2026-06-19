using Unity.Entities;
using Unity.NetCode;

public struct VelocityAffectedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity lastAffector;

	[GhostField]
	public int lastAffectorOptionIndex;
}
