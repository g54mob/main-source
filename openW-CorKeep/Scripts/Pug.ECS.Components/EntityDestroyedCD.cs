using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct EntityDestroyedCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	[GhostField]
	public TickTimer destroyTimer;
}
