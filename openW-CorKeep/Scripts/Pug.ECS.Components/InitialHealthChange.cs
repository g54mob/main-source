using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct InitialHealthChange : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	[GhostField]
	public HealthChange healthChange;
}
