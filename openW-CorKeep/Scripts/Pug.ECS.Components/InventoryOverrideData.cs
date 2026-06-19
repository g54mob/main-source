using Unity.Entities;

public struct InventoryOverrideData
{
	public bool hasAnyInventoryOverride;

	public bool hasLootTableOverride;

	public bool hasItemsOverride;

	public int itemsToRemove;

	public LootTableID lootTableOverride;

	public BlobArray<InitialInventoryItem> itemsOverride;
}
