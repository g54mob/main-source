using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
[GhostComponent(SendTypeOptimization = GhostSendType.OnlyPredictedClients)]
public struct IsBeingBeHealedByOtherEntitiesBuffer : IBufferElementData
{
	[GhostField]
	public int amountPerSecond;

	[GhostField]
	public Entity entityHealing;
}
