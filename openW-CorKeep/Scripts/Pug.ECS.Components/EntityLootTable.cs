using Unity.Entities;

public struct EntityLootTable
{
	public LootTableID lootTableID;

	public int minUniqueDrops;

	public int maxUniqueDrops;

	public bool dontAllowDuplicates;

	public BlobArray<EntityLootInfo> lootTable;

	public BlobArray<EntityLootInfo> guaranteedDropsLootTable;
}
