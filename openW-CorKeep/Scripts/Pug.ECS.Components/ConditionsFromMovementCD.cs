using Unity.Entities;
using Unity.NetCode;

public struct ConditionsFromMovementCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer standStillTimer;

	[GhostField]
	public TickTimer interactTimer;

	[GhostField]
	public TickTimer sleepyTimer;
}
