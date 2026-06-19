using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(SendTypeOptimization = GhostSendType.OnlyPredictedClients)]
[GhostEnabledBit]
public struct AffectedBySlipperyMovementConditionCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	[GhostField]
	public float3 previousVelocity;
}
