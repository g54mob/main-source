using Unity.Entities;
using Unity.NetCode;

[GhostComponent(SendTypeOptimization = GhostSendType.OnlyPredictedClients)]
public struct HealOverTimeConditionCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer timer;

	[GhostField]
	public float accumulatedHealing;
}
