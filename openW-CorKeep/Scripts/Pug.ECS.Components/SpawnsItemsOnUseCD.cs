using Unity.Entities;

public struct SpawnsItemsOnUseCD : IComponentData, IQueryTypeParameter
{
	public LootTableID lootTable;

	public EffectID spawnEffects;
}
