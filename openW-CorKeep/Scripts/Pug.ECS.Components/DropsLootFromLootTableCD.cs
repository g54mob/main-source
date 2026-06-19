using Unity.Entities;

public struct DropsLootFromLootTableCD : IComponentData, IQueryTypeParameter
{
	public LootTableID lootTableID;
}
