using Unity.Entities;
using Unity.NetCode;

public struct DestroyTimerCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer timer;

	public bool dontDropLootAfterTimerRunsOut;

	public uint disablePhysicsAfterTicks;

	public int startTimerWhenVariation;
}
