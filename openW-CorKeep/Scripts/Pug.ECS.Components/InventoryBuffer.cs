using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct InventoryBuffer : IBufferElementData
{
	[GhostField(SendData = false)]
	public int sizeX;

	[GhostField(SendData = false)]
	public int sizeY;

	[GhostField(SendData = false)]
	public int maxSize;

	[GhostField(SendData = false)]
	public int startIndex;

	[GhostField(SendData = false)]
	public bool canOnlyContainOneItemPerSlot;

	[GhostField(SendData = false)]
	public bool objectsGetLockedInPlace;

	[GhostField(SendData = false)]
	public bool cantAddObjectsToInventory;

	[GhostField(SendData = true)]
	public int extraSize;

	[GhostField(SendData = true)]
	public ulong extraInventoryCategoryTagsMask;

	[GhostField(SendData = false)]
	public int extraInventorySizeSlot;

	public int size => sizeX * sizeY + extraSize;
}
