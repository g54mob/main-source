using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(24)]
public struct SyncedPlayerSharedCooldownTimersCD : IBufferElementData
{
	[GhostField(Composite = false)]
	public TickTimer cooldown;
}
