using Unity.Entities;
using Unity.NetCode;

[GhostEnabledBit]
public struct AddRandomLootCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
	public LootTableID lootTableID;
}
