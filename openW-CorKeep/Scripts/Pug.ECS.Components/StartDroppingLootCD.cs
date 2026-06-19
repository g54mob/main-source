using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct StartDroppingLootCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public NetworkTick localLastStartTick;
}
