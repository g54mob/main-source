using Unity.Entities;
using Unity.NetCode;

[GhostComponent(SendTypeOptimization = GhostSendType.OnlyPredictedClients)]
public struct IsBeingBeHealedByOtherEntitiesCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer timer;

	[GhostField]
	public bool isBeingHealed;
}
