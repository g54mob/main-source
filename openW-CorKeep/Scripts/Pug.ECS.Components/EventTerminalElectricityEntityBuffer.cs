using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(0)]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EventTerminalElectricityEntityBuffer : IBufferElementData
{
	[GhostField(SendData = false)]
	public Entity entity;

	[GhostField(SendData = true)]
	public bool isActive;

	[GhostField(SendData = false)]
	public bool keepConnectionActive;
}
