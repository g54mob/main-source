using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
public struct ConditionTickTimerBuffer : IBufferElementData
{
	[GhostField]
	public ConditionID condition;

	[GhostField]
	public TickTimer tickTimer;
}
